using Shared;

namespace Producer
{
    public class RabbitServiceForOneToOne : RabbitQueueAbstractService
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekeyOneToOne;
    }

    public class RabbitServiceForOneToMany : RabbitQueueAbstractService
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekey;
    }
}
