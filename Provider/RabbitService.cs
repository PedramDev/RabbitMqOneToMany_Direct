using Shared;
using Volo.Abp.DependencyInjection;

namespace Producer
{
    public class RabbitServiceForOneToOne : RabbitQueueAbstractService, ISingletonDependency
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekeyOneToOne;
    }

    public class RabbitServiceForOneToMany : RabbitQueueAbstractService, ISingletonDependency
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekey;
    }
}
