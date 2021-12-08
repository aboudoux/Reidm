using Reidm.Application.Common;

namespace Reidm.Application.Buildings.Queries;

public class GetAllBuildingToStudy : IQuery<BuildingToStudyResult[]>{}

public record BuildingToStudyResult(string BuildingId, string BuildingLabel);

