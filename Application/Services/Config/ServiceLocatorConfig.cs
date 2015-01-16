using Domain.Commands;
using Domain.Commands.Handlers;
using Domain.DataBase;
using Domain.DomainServices;
using Domain.Entitys;
using Domain.Events;
using Domain.Events.Handlers;
using Infrastructure.Bus;
using Infrastructure.Commands;
using Infrastructure.Database;
using Infrastructure.Events;

namespace Application.Services.Config
{
    public class ServiceLocatorConfig
    {
        public static void Configura(Funq.Container container)
        {
            var context = new SampleContext();
            var orderService = new OrderService
            {
                EventBus = new EventBus(),
                OrderRepository = new Repository<Order, SampleContext>(context),
                EventStoreRepository = new Repository<EventStore, SampleContext>(context),
                PayOrderRepository = new Repository<PayOrder, SampleContext>(context)
            };
            var orderCommandHandler = new OrderCommandHandler { OrderService = orderService };
            var orderEventHandler = new OrderEventHandler { OrderService = orderService };
            container.Register<IOrderService>(c => orderService);
            container.Register<ICommandHandler<BuildOrder>>(c => orderCommandHandler);
            container.Register<IEventHandler<BuildOrderReady>>(c => orderEventHandler);
            container.Register<IEventHandler<PaySuccessReady>>(c => orderEventHandler);
        }
    }
}