using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reidm.Application.Buildings.Commands;
using Reidm.Application.Buildings.Queries;
using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Infrastructure;
using Reidm.infrastructure.Tests.Assets;
using Xunit;

namespace Reidm.infrastructure.Tests.Unitary 
{
	public class PlumbingTests 
	{
		[Fact(DisplayName = "Send command")]
		public async Task Test12()
		{
			using (var dir = TestDirectory.Create(Guid.NewGuid().ToString()))
			{
				IServiceCollection services = new ServiceCollection();
				services.RegisterApplicationDependencies(Path.Combine(dir.DirectoryPath, "database.es"), a => a.TryAddScoped<IConnectedUserService, FakeConnectedUserService>());

				var provider = services.BuildServiceProvider();

				var commandBus = provider.GetService<ICommandBus>();
				var queryBus = provider.GetService<IQueryBus>();

				await commandBus.SendAsync(new AddBuildingToStudy("TEST"));
				var result = await queryBus.QueryAsync(new GetAllBuildingToStudy());

				result.Should().HaveCount(1);
			}
		}
	}

	public class FakeConnectedUserService : IConnectedUserService
	{
		public string GetCurrentUserName() => "TEST USER";
	}
}
