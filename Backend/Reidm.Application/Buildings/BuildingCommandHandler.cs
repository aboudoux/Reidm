using Reidm.Application.Buildings.Commands;
using Reidm.Application.Common;
using Reidm.Domain.Buildings;
using Reidm.Domain.Common.Events;

namespace Reidm.Application.Buildings {
	public class BuildingCommandHandler : 
		ICommandHandler<AddBuildingToStudy>,
		ICommandHandler<ChangeBuildingInformation>
	{
		private readonly IEventBroker _eventBroker;

		public BuildingCommandHandler(IEventBroker eventBroker)
		{
			_eventBroker = eventBroker ?? throw new ArgumentNullException(nameof(eventBroker));
		}

		public async Task<CommandResult> Handle(AddBuildingToStudy command, CancellationToken cancellationToken)
		{
			var newBuilding = Building.ToStudy(command.Label);

			if (newBuilding.UncommittedEvents.IsEmpty)
				return CommandResult.NotApplied();
			
			await _eventBroker.Publish(newBuilding.UncommittedEvents);
			return CommandResult.Added(newBuilding.AggregateId);
		}

		public async Task<CommandResult> Handle(ChangeBuildingInformation command, CancellationToken cancellationToken)
		{
			var building = await _eventBroker.GetAggregate<Building>(command.BuildingId.Value);
			building.ChangeInfo(command.Information);

			if(building.UncommittedEvents.IsEmpty)
				return CommandResult.NotApplied();

			await _eventBroker.Publish(building.UncommittedEvents); 
			return CommandResult.Ok();
		}
	}
}
