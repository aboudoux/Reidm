using Reidm.Application.Buildings.Queries;
using Reidm.Application.Common;

namespace Reidm.Application.Buildings;

public class BuildingQueryHandler :
	IQueryHandler<GetAllBuildingToStudy, BuildingToStudyResult[]>,
	IQueryHandler<LoadBuilding, BuildingResult>
{
	private readonly IDatabaseRepository _repository;

	public BuildingQueryHandler(IDatabaseRepository repository)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}
	public Task<BuildingToStudyResult[]> Handle(GetAllBuildingToStudy query, CancellationToken cancellationToken)
	{
		return Task.FromResult(_repository.GetAllBuildingToStudy());
	}

	public Task<BuildingResult> Handle(LoadBuilding query, CancellationToken cancellationToken)
	{
		return Task.FromResult(_repository.LoadBuilding(query.BuildingId));
	}
}