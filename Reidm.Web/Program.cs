using System.Reflection;
using BlazorState;
using MudBlazor;
using MudBlazor.Services;
using Reidm.Application;
using Reidm.Application.Common;
using Reidm.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(config => {
	config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

	config.SnackbarConfiguration.PreventDuplicates = false;
	config.SnackbarConfiguration.NewestOnTop = false;
	config.SnackbarConfiguration.ShowCloseIcon = true;
	config.SnackbarConfiguration.VisibleStateDuration = 1500;
	config.SnackbarConfiguration.HideTransitionDuration = 300;
	config.SnackbarConfiguration.ShowTransitionDuration = 300;
	config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
});

builder.Services.AddBlazorState(options => {
	options.UseCloneStateBehavior = false;
	options.Assemblies = new[] { Assembly.GetExecutingAssembly() };
});


var path = builder.Configuration["DatabasePath"];
builder.Services.RegisterApplicationDependencies(path);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope()) {
	var commandBus = scope.ServiceProvider.GetRequiredService<ICommandBus>();
	await commandBus.SendAsync(new ReplayAllEvents());
}

app.Run();
