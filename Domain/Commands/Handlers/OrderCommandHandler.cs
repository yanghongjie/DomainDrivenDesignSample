using System.Threading.Tasks;
using Domain.DomainServices;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class OrderCommandHandler :CommandHandlerBase,
        ICommandHandler<BuildOrder>
    {
        public IOrderService OrderService { private get; set; }

        public async Task Handle(BuildOrder command)
        {
            await DoHandle(async c => { await OrderService.OrderBuild(command.ToOrder()); }, command);
        }
    }
}