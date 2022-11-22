using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;

namespace Consumer2
{
    public class AppModule
    {
        public static ServiceProvider Initialize()
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<RabbitServiceForOneToMany>()
           .BuildServiceProvider();


            #region One To Many (queue1)
            {
                var rabbitForMany = serviceProvider.GetRequiredService<RabbitServiceForOneToMany>();

                rabbitForMany.InitConsumer(CONSTS.queue2, CONSTS.exchangeProducer, CONSTS.routekey);

                EventHandler<BasicDeliverEventArgs> handler = (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" [x] Received '{0}':'{1}'",
                                      routingKey, message);
                };

                rabbitForMany.Consume(handler, CONSTS.queue2);
            }
            #endregion


            return serviceProvider;
        }
    }
}
