using Reidm.Application.Common;

namespace Reidm.Application.Buildings.Queries;

public record LoadBuilding(string BuildingId) : IQuery<BuildingResult>;