using System;
using System.Threading.Tasks;
using Infrastructure.Commands;

namespace Infrastructure.Bus
{
    public interface ICommandBus
    {
        CommandResult Excute<T>(T command) where T : ICommand;
        Task<CommandResult> ExcuteAsync<T>(T command) where T : ICommand;
    }
}