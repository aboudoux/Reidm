using MediatR;
using Reidm.Application.Common;

namespace Reidm.Infrastructure.Buses
{
    public class MediatrQueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public MediatrQueryBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}