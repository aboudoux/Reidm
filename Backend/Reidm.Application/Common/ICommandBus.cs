using MediatR;

namespace Reidm.Application.Common
{
    public interface ICommandBus
    {
        public Task<CommandResult> SendAsync(ICommand command);
    }

    public interface ICommand : IRequest<CommandResult>
    {
        
    }

    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, CommandResult>
        where TCommand : ICommand
    {
        
    }

    public record CommandResult()
    {
	    public static CommandResultOk Ok() => new();
	    public static CommandResultAdded Added(string id) => new(id);
	    public static CommandResultError Error(string errorMessage) => new(errorMessage);
	    public static CommandResultNotApplied NotApplied() => new();
    }

    public record CommandResultOk : CommandResult;
    public record CommandResultAdded(string Id) : CommandResultOk;
    public record CommandResultNotApplied : CommandResult;
    public record CommandResultError(string ErrorMessage) : CommandResult;


}