using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reidm.Application.Buildings;
using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;
using Reidm.Infrastructure.Buildings;
using Reidm.Infrastructure.Buses;
using Reidm.Infrastructure.Repositories;
using Reidm.Infrastructure.Serialization;

namespace Reidm.Infrastructure {
	public static class ServiceCollectionExtensions 
	{

		public static void RegisterApplicationDependencies(this IServiceCollection services, string databasePath, Action<IServiceCollection> config = null)
		{
			config?.Invoke(services);

			services.AddMediatR(typeof(BuildingQueryHandler).Assembly, typeof(BuildingEventHandler).Assembly);
			services.TryAddScoped<IEventBroker, EventBroker>();
			services.TryAddScoped<IEventDispatcher, MediatrEventDispatcher>();
			services.TryAddScoped<IConnectedUserService, EmptyConnectedUserService>();
			services.TryAddScoped<ICommandBus, MediatrCommandBus>();
			services.TryAddScoped<IQueryBus, MediatrQueryBus>();
			services.TryAddSingleton<ISerializer, CustomJsonSerializer>();

			services.TryAddSingleton<IEventStore>(a=>new FileEventStoreWithCache(a.GetRequiredService<ISerializer>(), databasePath));
			services.TryAddSingleton<IBuildingRepository, InMemoryBuildingRepository>();
			services.TryAddSingleton<IContactRepository, InMemoryContactRepository>();
		}
	}

	public class EmptyConnectedUserService : IConnectedUserService
	{
		public string GetCurrentUserName() => "Empty";
	}
}
