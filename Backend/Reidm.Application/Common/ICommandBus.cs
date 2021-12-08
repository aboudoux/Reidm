using MediatR;

namespace Reidm.Application.Common
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command);
    }

    public interface ICommand : INotification
    {
        
    }

    public interface ICommandHandler<in TCommand> : INotificationHandler<TCommand>
        where TCommand : ICommand
    {
        
    }        
}