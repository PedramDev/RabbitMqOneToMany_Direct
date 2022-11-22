using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;

namespace Consumer1
{
    public class AppModule
    {
        public static ServiceProvider Initialize()
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<RabbitServiceForOneToOne>()
           .AddSingleton<RabbitServiceForOneToMany>()
           .BuildServiceProvider();

            #region One To Many (queue1)
            {
                var rabbitForMany = serviceProvider.GetRequiredService<RabbitServiceForOneToMany>();

                rabbitForMany.InitConsumer(CONSTS.queue1, CONSTS.exchangeProducer, CONSTS.routekey);

                EventHandler<BasicDeliverEventArgs> handler = (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" [x_0] Received '{0}':'{1}'",
                                      routingKey, message);
                };

                rabbitForMany.Consume(handler, CONSTS.queue1);
            }
            #endregion


            #region One To One (queue3)
            {
                var rabbitForOne = serviceProvider.GetRequiredService<RabbitServiceForOneToOne>();

                rabbitForOne.InitConsumer(CONSTS.queue3, CONSTS.exchangeProducer, CONSTS.routekeyOneToOne);

                EventHandler<BasicDeliverEventArgs> handler = (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" [x_1] Received '{0}':'{1}'",
                                      routingKey, message);
                };

                rabbitForOne.Consume(handler, CONSTS.queue3);
            }
            #endregion

            return serviceProvider;
        }
    }
}
