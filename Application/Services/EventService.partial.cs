using System;
using System.Threading.Tasks;
using Infrastructure.Events;

namespace Application.Services
{
    public partial class EventService
    {
        private async Task<object> Handler<T>(T @event) where T : IEvent
        {
            try
            {
                await ResolveService<IEventHandler<T>>().Handle(@event);
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);
            }

            return null;
        }
    }
}