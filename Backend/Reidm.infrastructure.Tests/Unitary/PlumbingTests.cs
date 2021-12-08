using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reidm.Application;
using Reidm.Application.Buildings;
using Reidm.Application.Buildings.Commands;
using Reidm.Application.Buildings.Queries;
using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Domain.Common.Events;
using Reidm.Infrastructure;
using Reidm.Infrastructure.Buildings;
using Reidm.Infrastructure.Buses;
using Reidm.Infrastructure.Serialization;
using Xunit;

namespace Reidm.infrastructure.Tests.Unitary {
	public class PlumbingTests 
	{
		[Fact(DisplayName = "Send command")]
		public async Task Test12()
		{
			IServiceCollection services = new ServiceCollection();
			services.RegisterApplicationDependencies(a=>a.TryAddScoped<IConnectedUserService, FakeConnectedUserService>());

			var provider = services.BuildServiceProvider();

			var commandBus = provider.GetService<ICommandBus>();
			var queryBus = provider.GetService<IQueryBus>();

			await commandBus.SendAsync(new AddBuildingToStudy("TEST"));
			var result = await queryBus.QueryAsync(new GetAllBuildingToStudy());

			result.Should().HaveCount(1);
		}
	}

	public class FakeConnectedUserService : IConnectedUserService
	{
		public string GetCurrentUserName() => "TEST USER";
	}
}
