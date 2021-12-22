using MediatR;

namespace Reidm.Domain.Common.Events;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
	where TEvent : IEvent
{
}