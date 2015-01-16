using System;
using System.Threading.Tasks;
using Funq;
using Infrastructure.Commands;

namespace Application.Services
{
    public partial class CommandService
    {
        private async Task<CommandResult> Handler<T>(T command) where T : ICommand
        {
            try
            {
                await ResolveService<ICommandHandler<T>>().Handle(command);
            }
            catch (Exception e)
            {
                return new CommandResult(false, e.Message);
            }

            return new CommandResult(true, "Command Execute Finish!");
        }
    }
}