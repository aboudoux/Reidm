using Reidm.Application.Common;
using Reidm.Domain.Buildings.Events;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common.Events;

namespace Reidm.Infrastructure.Buildings {
	public class BuildingEventHandler : 
		IEventHandler<BuildingAddedToStudy>,
		IEventHandler<BuildingInfoChanged>
	{
		private readonly IBuildingRepository _repository;

		public BuildingEventHandler(IBuildingRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public Task Handle(BuildingAddedToStudy @event, CancellationToken cancellationToken)
		{
			_repository.AddBuildingToStudy(new BuildingId(@event.AggregateId), @event.Label);
			return Task.CompletedTask;
		}

		public Task Handle(BuildingInfoChanged @event, CancellationToken cancellationToken)
		{
			_repository.ChangeBuildingInfo(new BuildingId(@event.AggregateId), @event.Info);
			return Task.CompletedTask;
		}
	}
}
