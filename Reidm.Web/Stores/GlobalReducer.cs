using BlazorState;
using MediatR;
using MudBlazor;
using Reidm.Application.Buildings.Commands;
using Reidm.Application.Buildings.Queries;
using Reidm.Application.Common;
using Reidm.Domain.Buildings.Values;

namespace Reidm.Web.Stores
{
	public class GlobalReducer :
		ActionHandler<GlobalState.AddBuildingToStudy>,
		IRequestHandler<GlobalState.GetAllBuildingToStudy>,
		IRequestHandler<GlobalState.ChangeValue>,
		IRequestHandler<GlobalState.LoadBuilding>
	{
		private readonly ICommandBus _commandBus;
		private readonly IMediator _mediator;
		private readonly IQueryBus _queryBus;
		private readonly ISnackbar _snackbar;

		private GlobalState State => Store.GetState<GlobalState>();

		public GlobalReducer(IStore store, ICommandBus commandBus, IMediator mediator, IQueryBus queryBus, ISnackbar snackbar) : base(store)
		{
			_commandBus = commandBus;
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
			_queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
			_snackbar = snackbar ?? throw new ArgumentNullException(nameof(snackbar));
		}

		public override async Task<Unit> Handle(GlobalState.AddBuildingToStudy action, CancellationToken cancellationToken)
		{
			var result = await _commandBus.SendAsync(new AddBuildingToStudy(new BuildingLabel(action.Label)));
			if (result is not CommandResultAdded a) return Unit.Value;
			await _mediator.Send(new GlobalState.GetAllBuildingToStudy());
			await _mediator.Send(new GlobalState.NavigateTo("/building/" + a.Id, false));
			return Unit.Value;
		}

		public async Task<Unit> Handle(GlobalState.GetAllBuildingToStudy action, CancellationToken cancellationToken)
		{
			var result = await _queryBus.QueryAsync(new GetAllBuildingToStudy());
			State.BuildingsToStudy = result.ToDictionary(a=>a.BuildingId, b=>b);
			return Unit.Value;
		}

		public async Task<Unit> Handle(GlobalState.ChangeValue action, CancellationToken cancellationToken)
		{
			var result = await _commandBus.SendAsync(new ChangeBuildingInformation(action.BuildingId, action.Value));
			if (result == CommandResult.NotApplied())
				return Unit.Value;

			State.CurrentBuilding = action.Value switch
			{
				WantAdLink a => State.CurrentBuilding with { WantAddLink = a.Value},
				Address a => State.CurrentBuilding with { Address = a.Value },
				SellingPrice a => State.CurrentBuilding with { SellingPrice = a.Value },
				PropertyTax a => State.CurrentBuilding with { PropertyTax = a.Value },
				RoofCondition a => State.CurrentBuilding with { RoofCondition = a.Value },
				Surface a => State.CurrentBuilding with { Surface = a.Value },
				BuildYear a => State.CurrentBuilding with { BuildYear = a.Value },
				LastWorks a => State.CurrentBuilding with { LastWorks = a.Value },
				Comments a => State.CurrentBuilding with { Comments = a.Value },
				FacadeCondition a => State.CurrentBuilding with { FacadeCondition = a.Value },
				LastFacadeRepair a => State.CurrentBuilding with { LastFacadeRepair = a.Value },
				LastRoofRepair a => State.CurrentBuilding with { LastRoofRepair = a.Value },
				BuildingLabel a => State.CurrentBuilding with { Label = a.Value },
				Attics a => State.CurrentBuilding with{ Attics = a.Value},
				ClassifiedArea a => State.CurrentBuilding with{ ClassifiedArea = a.Value},
				Basement a => State.CurrentBuilding with{ Basement = a.Value},
				Cellar a => State.CurrentBuilding with{Cellar = a.Value},
				SewageServices a => State.CurrentBuilding with{SewageServices = a.Value},
				TownGas a => State.CurrentBuilding with{ TownGas = a.Value},
				SeparateElectricMeters a => State.CurrentBuilding with{ SeparateElectricMeters = a.Value},
				SeparateWaterMeters a => State.CurrentBuilding with{ SeparateWaterMeters = a.Value},
				WantAdText a => State.CurrentBuilding with{WantAddText = a.Value},
				BoilerCondition a => State.CurrentBuilding with{ BoilerCondition = a.Value},
				_ => throw new ArgumentOutOfRangeException()
			};

			if (State.BuildingsToStudy.ContainsKey(action.BuildingId))
			{
				State.BuildingsToStudy[action.BuildingId] = action.Value switch
				{
					BuildingLabel l => State.BuildingsToStudy[action.BuildingId] with {BuildingLabel = l.Value},
					Surface s => State.BuildingsToStudy[action.BuildingId] with {Surface = s.Value},
					SellingPrice s => State.BuildingsToStudy[action.BuildingId] with {SellingPrice = s.Value},
					_ => State.BuildingsToStudy[action.BuildingId]
				};
			}

			_snackbar.Add($"{ValueLabel()} enregistré(e)(s)", Severity.Success);
			return Unit.Value;

			string ValueLabel() => action.Value switch
			{
				WantAdLink => "Lien vers l'annonce",
				Address => "Adresse",
				SellingPrice => "Prix de vente",
				PropertyTax => "Taxe foncière",
				Surface => "Surface",
				BuildYear => "Année de construction",
				LastWorks => "Derniers travaux",
				Comments => "Remarques",
				BuildingLabel => "Label",
				Attics => "Comble",
				ClassifiedArea => "Zone classée",
				Basement => "Sous-sol",
				Cellar => "Cave",
				SewageServices => "tout à l'égout",
				TownGas => "Gaz",
				SeparateElectricMeters => "Compteurs éléctriques séparés",
				SeparateWaterMeters => "Compteurs de gaz séparés",
				FacadeCondition => "Etat de la façade",
				RoofCondition => "Etat de la toiture",
				LastFacadeRepair => "Dernier remaniement de façacde",
				LastRoofRepair => "Dernier remaniement de toiture",
				WantAdText => "Texte de l'annonce",
				BoilerCondition => "Etat de la chaudière",
				_ => "non défini"
			};
		}

		public async Task<Unit> Handle(GlobalState.LoadBuilding action, CancellationToken cancellationToken)
		{
			State.CurrentBuilding = await _queryBus.QueryAsync(new LoadBuilding(action.BuildingId));
			return Unit.Value;
		}
	}
}
