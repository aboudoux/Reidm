using BlazorState;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Reidm.Web.Stores.Buildings;

namespace Reidm.Web.Stores.Navigations;

public class NavigationReducer : 
	ActionHandler<BuildingState.OpenWantAdLink>,
	IRequestHandler<BuildingState.OpenBuildingAddress>,
	IRequestHandler<BuildingState.NavigateTo> 
{
	private readonly IMediator _mediator;
	private readonly NavigationManager _navigationManager;
	private readonly IJSRuntime _jsRuntime;

	public NavigationReducer(IStore store, IMediator mediator, NavigationManager navigationManager, IJSRuntime jsRuntime) : base(store)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		_navigationManager = navigationManager;
		_jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
	}
	public override async Task<Unit> Handle(BuildingState.OpenWantAdLink action, CancellationToken cancellationToken)
	{
		await _mediator.Send(new BuildingState.NavigateTo(action.url, true));
		return Unit.Value;
	}

	public async Task<Unit> Handle(BuildingState.OpenBuildingAddress action, CancellationToken cancellationToken) 
	{
		if (string.IsNullOrWhiteSpace(action.address)) return Unit.Value;
		await _mediator.Send(new BuildingState.NavigateTo("https://www.google.fr/maps/place/" + action.address.Replace(" ", "+").ReplaceLineEndings("+"), true)); 
		return Unit.Value;
	}

	public async Task<Unit> Handle(BuildingState.NavigateTo action, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(action.Url)) return Unit.Value;
		if(action.NewTab)
			await _jsRuntime.InvokeAsync<object>("Open", action.Url, "_blank");
		else
			_navigationManager.NavigateTo(action.Url);
		
		return Unit.Value;
	}
}