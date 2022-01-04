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

	public record NavigateTo : IAction
	{
		public string Url { get; }
		public bool NewTab { get; }

		public NavigateTo(string url, bool newTab)
		{
			Url = !string.IsNullOrWhiteSpace(url) && 
			      (url.ToLower().StartsWith("http://") ||
			      url.ToLower().StartsWith("https://"))
				? url
				: "http://" + url;

			NewTab = newTab;
		}
	}

	public record AddBuildingToStudy(string Label) : IAction;

	public record GetAllBuildingToStudy : IAction;

	public record ChangeValue(string BuildingId, IBuildingValue Value) : IAction;

	public record LoadBuilding(string BuildingId) : IAction;

	public record OpenWantAdLink(string url) : IAction;

	public record OpenBuildingAddress(string address) : IAction;
}

public record BuildingToStudyItem(string Id, string Label);