using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Producer
{
    public class AppModule
    {
        public static ServiceProvider Initialize()
        {
            var serviceProvider = new ServiceCollection()
           .AddSingleton<RabbitServiceForOneToOne>()
           .AddSingleton<RabbitServiceForOneToMany>()
           .BuildServiceProvider();

            var rabbitForOne = serviceProvider.GetRequiredService<RabbitServiceForOneToOne>();
            var rabbitForMany = serviceProvider.GetRequiredService<RabbitServiceForOneToMany>();

            rabbitForMany.InitProducer(new string[] { CONSTS.queue1, CONSTS.queue2 }, CONSTS.exchangeProducer, CONSTS.routekey);

            rabbitForOne.InitProducer(CONSTS.queue3, CONSTS.exchangeProducer, CONSTS.routekeyOneToOne);


            return serviceProvider;
        }
    }
}
