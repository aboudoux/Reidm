namespace Reidm.Domain.Common.Events
{
    public sealed class UncommittedEvents : EventStream {
        public UncommittedEvents() {
        }

        public UncommittedEvents(IEnumerable<IDomainEvent> events) : base(events) {
        }
    }
}