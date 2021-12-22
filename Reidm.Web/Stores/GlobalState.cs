using BlazorState;
using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Web.Stores;

public class GlobalState : State<GlobalState>
{
	public Dictionary<string,string> BuildingToStudy { get; set; }

	public BuildingResult CurrentBuilding { get; set; }

	public override void Initialize()
	{
		BuildingToStudy = new Dictionary<string, string>();
		CurrentBuilding = BuildingResult.Empty();
	}

	public record NavigateTo(string Url, bool NewTab) : IAction;

	public record AddBuildingToStudy(string Label) : IAction;

	public record GetAllBuildingToStudy : IAction;

	public record ChangeValue(string BuildingId, IBuildingValue Value) : IAction;

	public record LoadBuilding(string BuildingId) : IAction;

	public record OpenWantAdLink(string url) : IAction;

	public record OpenBuildingAddress(string address) : IAction;
}

public record BuildingToStudyItem(string Id, string Label);