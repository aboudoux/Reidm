using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Infrastructure;
using Reidm.infrastructure.Tests.Assets;
using Reidm.infrastructure.Tests.Unitary;

namespace Reidm.infrastructure.Tests.Steps {
	public abstract class StepBase : IDisposable
	{
		private ICommandBus _commandBus;
		private IQueryBus _queryBus;
		private TestDirectory _directory;

		protected StepBase()
		{
			_directory = TestDirectory.Create(Guid.NewGuid().ToString());
			IServiceCollection services = new ServiceCollection();
			services.RegisterApplicationDependencies(Path.Combine(_directory.DirectoryPath,"database.es"), a => a.TryAddScoped<IConnectedUserService, FakeConnectedUserService>());

			var provider = services.BuildServiceProvider();

			_commandBus = provider.GetService<ICommandBus>() ?? throw new ArgumentNullException("CommandBus");
			_queryBus = provider.GetService<IQueryBus>() ?? throw new ArgumentNullException("QueryBus");
		}

		public async Task SendCommand(ICommand command) => await _commandBus.SendAsync(command);
		public async Task<TResult> Query<TResult>(IQuery<TResult> query) => await _queryBus.QueryAsync(query);

		public void Dispose()
		{
			_directory?.Dispose();
		}
	}
}
