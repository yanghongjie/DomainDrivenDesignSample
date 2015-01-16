using System.Threading.Tasks;
using Domain.Entitys;
using Infrastructure.Bus;
using Infrastructure.Database;

namespace Domain.DomainServices
{
    public class OrderService : IOrderService
    {
        public IRepository<Order> OrderRepository { private get; set; }
        public IRepository<PayOrder> PayOrderRepository { private get; set; }
        public IRepository<EventStore> EventStoreRepository { private get; set; }
        public IEventBus EventBus { private get; set; }

        public async Task OrderBuild(Order order)
        {
            //生成订单
            await OrderRepository.AddAsync(order);
            //toEventStore
            await EventStoreRepository.AddAsync(order.ToBuildOrderReadyEvent().ToEventStore());
            //发布生成订单事件
            EventBus.Publish(order.ToBuildOrderReadyEvent());
        }

        public async Task Pay(Order order)
        {
            var payOrder = new PayOrder
            {
                OrderNo = order.OrderNo,
                PayAmount = order.OrderAmount,
                PayResult = "pay success!"
            };
            //支付成功
            await PayOrderRepository.AddAsync(payOrder);
            //更新订单
            var findOrder = await OrderRepository.GetByKeyAsync(order.Id);
            findOrder.IsPaid = true;
            await OrderRepository.UpdateAsync(findOrder);
            //toEventStore
            await EventStoreRepository.AddAsync(payOrder.ToPaySuccessReadyEvent().ToEventStore());
            //发布支付成功事件
            EventBus.Publish(payOrder.ToPaySuccessReadyEvent());
        }
    }
}