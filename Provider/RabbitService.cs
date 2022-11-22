using Shared;
using Volo.Abp.DependencyInjection;

namespace Producer
{
    public class RabbitServiceForOneToOne : RabbitQueueAbstractService, ISingletonDependency
    {
    }

    public class RabbitServiceForOneToMany : RabbitQueueAbstractService, ISingletonDependency
    {
    }
}
