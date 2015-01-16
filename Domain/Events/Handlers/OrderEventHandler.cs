using System.Threading.Tasks;
using Domain.DomainServices;
using Infrastructure.Events;

namespace Domain.Events.Handlers
{
    public class OrderEventHandler : EventHandlerBase,
        IEventHandler<BuildOrderReady>,
        IEventHandler<PaySuccessReady>
    {
        public IOrderService OrderService { private get; set; }
        public async Task Handle(BuildOrderReady @event)
        {
            await DoHandle(async c => { await OrderService.Pay(@event.Entity); }, @event);
        }

        public async Task Handle(PaySuccessReady @event)
        {
            //Send Email..
            //Send SMS..
        }
    }
}