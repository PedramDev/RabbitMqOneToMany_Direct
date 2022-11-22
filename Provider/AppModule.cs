using Microsoft.Extensions.DependencyInjection;
using Shared;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Producer
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
            var rabbitForOne = context.ServiceProvider.GetRequiredService<RabbitServiceForOneToOne>();
            var rabbitForMany = context.ServiceProvider.GetRequiredService<RabbitServiceForOneToMany>();

            rabbitForMany.InitProducer(new string[] { CONSTS.queue1, CONSTS.queue2 }, CONSTS.exchangeProducer, CONSTS.routekey);

            rabbitForOne.InitProducer(CONSTS.queue3, CONSTS.exchangeProducer, CONSTS.routekeyOneToOne);
        }
    }
}
