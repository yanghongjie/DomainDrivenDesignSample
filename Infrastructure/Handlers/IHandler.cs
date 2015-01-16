using System.Threading.Tasks;

namespace Infrastructure.Handlers
{
    public interface IHandler<in TMessage>
    {
        Task Handle(TMessage message);
    }
}