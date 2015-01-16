using System.Threading.Tasks;
using Domain.Events;
using ServiceStack;

namespace Application.Services
{
    public partial class EventService : Service
    {
        public async Task Any(BuildOrderReady @event)
        {
            await Handler(@event);
        }

        public async Task Any(PaySuccessReady @event)
        {
            await Handler(@event);
        }
    }
}