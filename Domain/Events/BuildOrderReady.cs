﻿using System;
using Domain.Entitys;
using Infrastructure.Events;
using Newtonsoft.Json;

namespace Domain.Events
{
    public class BuildOrderReady : Event
    {
        public Order Entity { get; set; }

        public EventStore ToEventStore()
        {
            return new EventStore
            {
                Timestamp = DateTime.Now,
                Body = JsonConvert.SerializeObject(Entity)
            };
        }
    }
}