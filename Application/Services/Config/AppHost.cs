using System.Configuration;
using Domain.Commands;
using Domain.Commands.Handlers;
using Domain.DataBase;
using Domain.Entitys;
using Domain.Events;
using Domain.Events.Handlers;
using Infrastructure.Bus;
using Infrastructure.Commands;
using Infrastructure.Database;
using Infrastructure.Events;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Messaging;
using ServiceStack.RabbitMq;

namespace Application.Services.Config
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("CQRS Demo", typeof(AppHost).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //SwaggerUI配置用于调试
            AddPlugin(new SwaggerFeature());

            //IOC配置
            ServiceLocatorConfig.Configura(container);

            //rabbitmq配置
            var mq = new RabbitMqServer(ConfigurationManager.AppSettings.Get("EventProcessorAddress"))
            {
                AutoReconnect = true,
                DisablePriorityQueues = true,
                RetryCount = 0
            };
            container.Register<IMessageService>(c => mq);
            var mqServer = container.Resolve<IMessageService>();

            //注册eventHandler
            mq.RegisterHandler<BuildOrderReady>(ServiceController.ExecuteMessage, 1);
            mq.RegisterHandler<PaySuccessReady>(ServiceController.ExecuteMessage, 1);

            mqServer.Start();
        }
    }
}