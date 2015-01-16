using Infrastructure.Handlers;

namespace Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand> : IHandler<TCommand>
       where TCommand : ICommand
    {
    }
}