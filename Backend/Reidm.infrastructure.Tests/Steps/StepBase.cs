using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reidm.Application.Common;
using Reidm.Domain.Common;
using Reidm.Infrastructure;
using Reidm.infrastructure.Tests.Unitary;

namespace Reidm.infrastructure.Tests.Steps {
	public abstract class StepBase
	{
		private ICommandBus _commandBus;
		private IQueryBus _queryBus;
		protected StepBase()
		{
			IServiceCollection services = new ServiceCollection();
			services.RegisterApplicationDependencies("database.es",a => a.TryAddScoped<IConnectedUserService, FakeConnectedUserService>());

			var provider = services.BuildServiceProvider();

			_commandBus = provider.GetService<ICommandBus>() ?? throw new ArgumentNullException("CommandBus");
			_queryBus = provider.GetService<IQueryBus>() ?? throw new ArgumentNullException("QueryBus");
		}

		public async Task SendCommand(ICommand command) => await _commandBus.SendAsync(command);
		public async Task<TResult> Query<TResult>(IQuery<TResult> query) => await _queryBus.QueryAsync(query);
	}
}
