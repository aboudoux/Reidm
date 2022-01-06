using System.Reflection;
using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;
using Reidm.Infrastructure.Serialization;

namespace Reidm.Infrastructure 
{
    public sealed class FileEventStoreWithCache : IEventStore
    {
        private readonly ISerializer _serializer;
        private readonly string _eventStoreFileName;
        private readonly BackGroundWriter _backgroundWriter;

        public static string EventStoreDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private readonly string _defaultDatabase = Path.Combine(EventStoreDirectory, "database.es");

        private List<IDomainEvent> _cacheEvents = new();

        public FileEventStoreWithCache(ISerializer serializer) 
            : this(serializer, null)
        {
        }

        public FileEventStoreWithCache(ISerializer serializer, string filePath = null)
        {
            if (filePath.IsEmpty())
                filePath = _defaultDatabase;
            if(!Directory.Exists(Path.GetDirectoryName(filePath)))
                throw new DirectoryNotFoundException(filePath);

            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));            
            _eventStoreFileName = filePath;

            if (File.Exists(filePath))
                LoadAllEventInCache();

            _backgroundWriter = new BackGroundWriter(filePath, serializer);
        }

        public Task<IDomainEvent[]> GetEvents(Predicate<IDomainEvent> predicate)
        {            
            return Task.FromResult(_cacheEvents.Where(@event => predicate(@event)).ToArray());
        }

        private void LoadAllEventInCache()
        {
            _cacheEvents = File.ReadLines(_eventStoreFileName)
                .Select(line => _serializer.Deserialize(line) as IDomainEvent)
                .ToList();
        }

        public async Task Save(IEnumerable<IDomainEvent> events)
            => await events.ForEachAsync(async e => await Save(e));

        public async Task Save(IDomainEvent @event)
        {
            _backgroundWriter.Save(@event);
            _cacheEvents.Add(@event);
            await _backgroundWriter.Flush();
        }

        public Task<int> GetLastSequence(string aggregateId)
        {
            var selectedEvents = _cacheEvents.Where(@event => @event.AggregateId == aggregateId).ToList();

            return Task.FromResult(selectedEvents.Any()
                ? selectedEvents.Max(e => e.Sequence)
                : -1);
        }

        private class BackGroundWriter
        {
            private readonly string _filePath;
            private readonly ISerializer _serializer;
            private readonly Queue<IDomainEvent> _blockingCollection = new();   
            
            public BackGroundWriter(string filePath, ISerializer serializer)
            {
                _filePath = filePath;
                _serializer = serializer;           
            }
            
            public void Save(IDomainEvent @event) => _blockingCollection.Enqueue(@event);

            public async Task Flush()
            {
                while (_blockingCollection.Count > 0)
                {
                    var eventToSerialize = _blockingCollection.Dequeue();
                    if(eventToSerialize == null)
                        continue;

                    await File.AppendAllTextAsync(_filePath, _serializer.Serialize(eventToSerialize) + Environment.NewLine);
				}
            }           
        }        
    }
}
