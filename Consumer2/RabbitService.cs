using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer2
{
    public class RabbitServiceForOneToMany : RabbitQueueAbstractService
    {
        public override string Exchange => CONSTS.exchangeProducer;

        public override string RouteKey => CONSTS.routekey;
    }
}
