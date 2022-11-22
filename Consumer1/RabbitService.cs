using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer1
{
    public class RabbitServiceForOneToMany : RabbitQueueAbstractService
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekey;
    }

    public class RabbitServiceForOneToOne : RabbitQueueAbstractService
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekeyOneToOne;
    }
}
