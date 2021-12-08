using Reidm.Application.Buildings.Queries;
using Reidm.Application.Common;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Infrastructure.Repositories;

public class InMemoryDatabaseRepository : IDatabaseRepository
{
	private Dictionary<string, BuildingResult> _allBuildings = new();

	public void AddBuildingToStudy(string buildingId, BuildingLabel label)
	{
		if(_allBuildings.ContainsKey(buildingId)) return;
		_allBuildings.Add(buildingId, new BuildingResult {Label = label.Value});
	}

	public void ChangeBuildingInfo(string buildingId, IBuildingValue info)
	{
		if (!_allBuildings.ContainsKey(buildingId)) throw new ArgumentException($"Building {buildingId} not found");

		_allBuildings[buildingId] = info switch
		{
			BuildYear i => _allBuildings[buildingId] with { BuildYear = i.Value },
			ClassifiedArea i => _allBuildings[buildingId] with { ClassifiedArea = i.Value },
			Comments i => _allBuildings[buildingId] with { Comments = i.Value },
			FacadeCondition i => _allBuildings[buildingId] with { FacadeCondition = i.Value },
			LastFacadeRepair i => _allBuildings[buildingId] with { LastFacadeRepair = i.Value },
			LastRoofRepair i => _allBuildings[buildingId] with { LastRoofRepair = i.Value },
			LastWorks i => _allBuildings[buildingId] with { LastWorks = i.Value },
			PropertyTax i => _allBuildings[buildingId] with { PropertyTax = i.Value },
			RoofCondition i => _allBuildings[buildingId] with { RoofCondition = i.Value },
			SellingPrice i => _allBuildings[buildingId] with { SellingPrice = i.Value },
			SeparateElectricMeters i => _allBuildings[buildingId] with { SeparateElectricMeters = i.Value },
			SeparateWaterMeters i => _allBuildings[buildingId] with { SeparateWaterMeters = i.Value },
			Surface i => _allBuildings[buildingId] with { Surface = i.Value },
			TownGas i => _allBuildings[buildingId] with { TownGas = i.Value },
			WantAdLink i => _allBuildings[buildingId] with { WantAddLink = i.Value },
			Address i => _allBuildings[buildingId] with { Address = i.Value },
			Attics i => _allBuildings[buildingId] with { Attics = i.Value },
			Basement i => _allBuildings[buildingId] with { Basement = i.Value },
			BuildingLabel i => _allBuildings[buildingId] with { Label = i.Value },
			SewageServices i => _allBuildings[buildingId] with { SewageServices = i.Value },
			Cellar i => _allBuildings[buildingId] with{ Cellar = i.Value},
			WantAdText i => _allBuildings[buildingId] with{ WantAddText = i.Value},
			BoilerCondition i => _allBuildings[buildingId] with { BoilerCondition = i.Value },
			_ => throw new ArgumentOutOfRangeException(nameof(info), info, null)
		};
	}

	public BuildingToStudyResult[] GetAllBuildingToStudy()
	{
		return _allBuildings.Select(a 
			=> new BuildingToStudyResult(a.Key, a.Value.Label)).ToArray();
	}

	public BuildingResult LoadBuilding(string buildingId)
	{
		if (!_allBuildings.ContainsKey(buildingId)) throw new ArgumentException($"Building {buildingId} not found");
		return _allBuildings[buildingId];
	}
}