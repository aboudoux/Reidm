using Reidm.Application.Common;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Application.Buildings.Commands;

public record ChangeBuildingInformation(string BuildingId, IBuildingValue Information) : ICommand;