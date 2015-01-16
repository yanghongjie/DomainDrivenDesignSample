using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public abstract class EventHandlerBase
    {
        public virtual async Task DoHandle<TMessage>(Func<TMessage, Task> handlerAction, TMessage message) where TMessage : IEvent
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