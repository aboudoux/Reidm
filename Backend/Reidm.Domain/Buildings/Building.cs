using Reidm.Domain.Buildings.Events;
using Reidm.Domain.Buildings.Values;
using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;

namespace Reidm.Domain.Buildings {
	public class Building : AggregateRoot<BuildingState>
	{
		public Building(History history) : base(history)
		{
			
		}

		public static Building ToStudy(BuildingLabel label) 
			=> CreateNew<Building>(Guid.NewGuid().ToString(), new BuildingAddedToStudy(label));

		public void ChangeInfo(IBuildingValue buildingValue)
		{
			if(State.IsValueChanged(buildingValue))
				RaiseEvent(new BuildingInfoChanged(buildingValue));
		}
	}
}
