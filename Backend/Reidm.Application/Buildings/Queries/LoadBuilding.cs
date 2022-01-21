using Reidm.Application.Common;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Application.Buildings.Queries;

public record LoadBuilding(BuildingId BuildingId) : IQuery<BuildingResult>;