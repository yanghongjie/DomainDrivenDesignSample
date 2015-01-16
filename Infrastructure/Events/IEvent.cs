using System;
using ServiceStack;

namespace Infrastructure.Events
{
    public interface IEvent : IReturnVoid
    {
        Guid EventId { get; } 
    }
}