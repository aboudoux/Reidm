namespace Reidm.Application.Buildings.Queries;

public record BuildingResult
{
	public string Address{get;init;} = string.Empty;
	public bool Attics{get;init;}
	public bool Basement{get;init;}
	public bool Cellar { get; init; }
	public string Label{get;init;} = string.Empty;
	public int BuildYear{get;init;}
	public bool ClassifiedArea{get;init;}
	public string Comments{get;init;} = string.Empty;
	public string LastWorks{get;init;} = string.Empty;
	public int PropertyTax{get;init;}
	public int SellingPrice{get;init;}
	public bool SeparateElectricMeters{get;init;}
	public bool SeparateWaterMeters{get;init;}
	public bool SewageServices{get;init;}
	public int Surface{get;init;}
	public bool TownGas { get;init;}
	public string WantAddLink{get; init;} = string.Empty;
	public string WantAddText{get; init;} = string.Empty;

	public int RoofCondition { get; init; }
	public DateTime? LastRoofRepair { get; init; }
	public int FacadeCondition { get; init; }
	public DateTime? LastFacadeRepair { get; init; }

	public int BoilerCondition { get; init; }

	public static BuildingResult Empty() => new();
}