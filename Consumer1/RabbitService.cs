﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Consumer1
{
    public class RabbitServiceForOneToMany : RabbitQueueAbstractService, ISingletonDependency
    {
    }

    public class RabbitServiceForOneToOne : RabbitQueueAbstractService, ISingletonDependency
    {
    }
}
