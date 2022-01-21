using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Application.Common;

public interface IBuildingRepository
{
	public void AddBuildingToStudy(BuildingId buildingId, BuildingLabel label);
	public void ChangeValue(BuildingId buildingId, IBuildingValue value);
	public BuildingToStudyResult[] GetAllBuildingToStudy();

	public BuildingResult LoadBuilding(BuildingId buildingId);
}