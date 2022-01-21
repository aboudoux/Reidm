using BlazorState;
using Reidm.Application.Buildings.Queries;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Web.Stores.Buildings;

public class BuildingState : State<BuildingState>
{
	public Dictionary<string,BuildingToStudyResult> BuildingsToStudy { get; set; }

	public BuildingResult CurrentBuilding { get; set; }

	public override void Initialize()
	{
		BuildingsToStudy = new Dictionary<string, BuildingToStudyResult>();
		CurrentBuilding = BuildingResult.Empty();
	}

	public record NavigateTo : IAction
	{
		public string Url { get; }
		public bool NewTab { get; }

		public NavigateTo(string url, bool newTab)
		{
			var _url = url == null ? string.Empty : url;
			_url = _url.Trim().ToLower();

			Url = !string.IsNullOrWhiteSpace(_url) && 
			      (_url.StartsWith("http://") ||
			       _url.StartsWith("https://")) || _url.StartsWith("/")
				? _url
				: "http://" + _url;

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
