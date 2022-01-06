using MediatR;
using Reidm.Domain.Common.Events;

namespace Reidm.Infrastructure.Buses
{
    public class MediatrEventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;

        public MediatrEventDispatcher(IMediator mediator) 
            => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        public async Task Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            await _mediator.Publish(@event);
        }
    }
}