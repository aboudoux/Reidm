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

		public static void RegisterApplicationDependencies(this IServiceCollection services, Action<IServiceCollection> config = null)
		{
			config?.Invoke(services);

			services.AddMediatR(typeof(BuildingQueryHandler).Assembly, typeof(BuildingEventHandler).Assembly);
			services.TryAddScoped<IEventBroker, EventBroker>();
			services.TryAddScoped<IEventDispatcher, MediatrEventDispatcher>();
			services.TryAddScoped<IConnectedUserService, EmptyConnectedUserService>();
			services.TryAddScoped<ICommandBus, MediatrCommandBus>();
			services.TryAddScoped<IQueryBus, MediatrQueryBus>();

			services.TryAddSingleton<IEventStore, FileEventStoreWithCache>();
			services.TryAddSingleton<ISerializer, CustomJsonSerializer>();
			services.TryAddSingleton<IDatabaseRepository, InMemoryDatabaseRepository>();
		}
	}

	public class EmptyConnectedUserService : IConnectedUserService
	{
		public string GetCurrentUserName() => "Empty";
	}
}
