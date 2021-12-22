using MediatR;
using Reidm.Application.Common;

namespace Reidm.Infrastructure.Buses
{
    public class MediatrCommandBus : ICommandBus
    {
        private readonly IMediator _mediator;
        public MediatrCommandBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<CommandResult> SendAsync(ICommand command)
        {
            return await _mediator.Send(command);
        }
    }
}