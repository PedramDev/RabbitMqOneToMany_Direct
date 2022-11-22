using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Consumer2
{
    [DependsOn(typeof(AbpAutofacModule), typeof(ShareModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAssemblyOf<AppModule>();
        }

        public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

            #region One To Many (queue1)
            {
                var rabbitForMany = context.ServiceProvider.GetRequiredService<RabbitServiceForOneToMany>();

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

        }
    }
}
