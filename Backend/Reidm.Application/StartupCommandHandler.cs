using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;

namespace Reidm.Application
{
    public class StartupCommandHandler : ICommandHandler<ReplayAllEvents>
    {
        private readonly IEventStore _eventStore;
        private readonly IEventDispatcher _dispatcher;


        public StartupCommandHandler(IEventStore eventStore, IEventDispatcher dispatcher)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<CommandResult> Handle(ReplayAllEvents context, CancellationToken cancellationToken)
        {
            var allEvents = await _eventStore.GetEvents(a => true);
            await allEvents.ForEachAsync(async (e) => await _dispatcher.Dispatch(e));
            return CommandResult.Ok();
        }
    }
}