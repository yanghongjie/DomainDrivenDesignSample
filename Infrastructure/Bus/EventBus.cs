using System;
using System.Configuration;
using Infrastructure.Events;
using ServiceStack;
using ServiceStack.RabbitMq;

namespace Infrastructure.Bus
{
    public class EventBus : IEventBus
    {
        private readonly RabbitMqServer mqServer;

        public EventBus()
        {
            mqServer = InitRabbitMqServer();
        }

        public void Publish<T>(T message) where T : IEvent
        {
            try
            {
                using (var eventBus = mqServer.CreateMessageProducer())
                {
                    eventBus.Publish(message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private RabbitMqServer InitRabbitMqServer()
        {
            return new RabbitMqServer(ConfigurationManager.AppSettings.Get("EventProcessorAddress"))
            {
                AutoReconnect = true,
                DisablePriorityQueues = true
            };
        }
    }
}