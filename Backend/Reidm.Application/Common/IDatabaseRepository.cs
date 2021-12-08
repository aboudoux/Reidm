using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Application.Common;

public interface IDatabaseRepository
{
	public void AddBuildingToStudy(string buildingId, BuildingLabel label);
	public void ChangeBuildingInfo(string buildingId, IBuildingValue info);
	public BuildingToStudyResult[] GetAllBuildingToStudy();

	public BuildingResult LoadBuilding(string buildingId);

}

