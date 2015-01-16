using Infrastructure.Handlers;

namespace Infrastructure.Events
{
    public interface IEventHandler<in TEvent> : IHandler<TEvent>
          where TEvent : IEvent
    {
    }
}