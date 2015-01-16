using System;

namespace Infrastructure.Events
{
    [Serializable]
    public abstract class Event : IEvent
    {
        protected Event()
        {
            this.EventId = Guid.NewGuid();
        }
        public Guid EventId { get; set; }
    }
}