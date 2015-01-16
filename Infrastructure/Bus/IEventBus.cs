using System;
using Infrastructure.Events;

namespace Infrastructure.Bus
{
    public interface IEventBus 
    {
        void Publish<T>(T message) where T : IEvent;
    }
}