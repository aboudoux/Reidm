using Newtonsoft.Json;

namespace Reidm.Domain.Common.Events
{
    public abstract record DomainEvent : IDomainEvent, IEventMetaData,  ISerializableType
    {
        [JsonProperty]
        public string AggregateId { get; private set; }
        [JsonProperty]
        public int Sequence { get; private set; }
        [JsonProperty]
        public string UserName { get; private set; }
        [JsonProperty]
        public DateTimeOffset CreationDate { get; private set; }

        void IEventMetaData.SetIdentifiers(string aggregateId, int sequence)
        {
            AggregateId = aggregateId;
            Sequence = sequence;            
        }

        void IEventMetaData.SetCreationInfos(string userName, DateTimeOffset creationDate)
        {
            UserName = userName;
            CreationDate = creationDate;
        }
    }
}