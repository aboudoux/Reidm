using Reidm.Domain.Buildings.Values;

namespace Reidm.infrastructure.Tests {
	public interface IBuildingRepository
	{
		void AddBuilding(BuildingLabel label);
		void UpdateBuilding(string buildingId, IBuildingValue value);

	}
}
