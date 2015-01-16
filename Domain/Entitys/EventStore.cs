using System;
using Infrastructure.Database;

namespace Domain.Entitys
{
    public class EventStore : EntityBase
    {
        public string Body { get; set; }

        public DateTime Timestamp { get; set; }
    }
}