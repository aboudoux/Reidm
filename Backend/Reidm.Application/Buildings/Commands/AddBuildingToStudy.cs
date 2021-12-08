using Reidm.Application.Common;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Application.Buildings.Commands {
	public record AddBuildingToStudy(BuildingLabel Label) : ICommand;
}
