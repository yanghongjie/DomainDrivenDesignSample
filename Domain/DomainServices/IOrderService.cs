using System.Threading.Tasks;
using Domain.Entitys;

namespace Domain.DomainServices
{
    public interface IOrderService
    {
        Task OrderBuild(Order order);

        Task Pay(Order order);
    }
}