namespace Reidm.Domain.Common.Events
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}