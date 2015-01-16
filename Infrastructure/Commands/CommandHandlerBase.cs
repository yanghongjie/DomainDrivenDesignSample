using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public abstract class CommandHandlerBase
    {
        protected async Task DoHandle<TMessage>(Func<TMessage, Task> handlerAction, TMessage message) where TMessage : ICommand
        {
            try
            {
                await handlerAction.Invoke(message);
            }
            //catch MoreException
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}