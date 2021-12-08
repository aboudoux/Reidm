using BlazorState;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Reidm.Web.Stores;

public class NavigationReducer : 
	ActionHandler<GlobalState.OpenWantAdLink>,
	IRequestHandler<GlobalState.OpenBuildingAddress>,
	IRequestHandler<GlobalState.NavigateTo> 
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
	public override async Task<Unit> Handle(GlobalState.OpenWantAdLink action, CancellationToken cancellationToken)
	{
		await _mediator.Send(new GlobalState.NavigateTo(action.url, true));
		return Unit.Value;
	}

	public async Task<Unit> Handle(GlobalState.OpenBuildingAddress action, CancellationToken cancellationToken) 
	{
		if (string.IsNullOrWhiteSpace(action.address)) return Unit.Value;
		await _mediator.Send(new GlobalState.NavigateTo("https://www.google.fr/maps/place/" + action.address.Replace(" ", "+").ReplaceLineEndings("+"), true)); 
		return Unit.Value;
	}

	public async Task<Unit> Handle(GlobalState.NavigateTo action, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(action.Url)) return Unit.Value;
		if(action.NewTab)
			await _jsRuntime.InvokeAsync<object>("open", action.Url, "_blank");
		else
			_navigationManager.NavigateTo(action.Url);
		
		return Unit.Value;
	}
}