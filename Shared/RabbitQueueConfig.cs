using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Shared
{
    public abstract class RabbitQueueAbstractService : IDisposable
    {
        public IConnection Connection { get; private set; }
        public IModel Model { get; private set; }

        private void Init()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Connection = factory.CreateConnection();
            Model = Connection.CreateModel();
        }

        /// <summary>
        /// Use One time Only
        /// </summary>
        public void InitConsumer(string queue,string exchange,string routeKey)
        {
            Init();

            Model.QueueDeclare(queue: queue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Model.QueueBind(queue, exchange, routeKey);
        }

        /// <summary>
        /// Use One time Only
        /// </summary>
        public void InitProducer(string queue, string exchange, string routeKey)
        {
            InitProducer(new string[] { queue }, exchange, routeKey);
        }

        /// <summary>
        /// Use One time Only
        /// </summary>
        public void InitProducer(string[] queueList,string exchange,string routeKey)
        {
            Init();

            Model.ExchangeDeclare(CONSTS.exchangeProducer, ExchangeType.Direct, true, false);

            foreach (var queue in queueList)
            {
                Model.QueueDeclare(queue: queue,
                                               durable: true,
                                               exclusive: false,
                                               autoDelete: false,
                                               arguments: null);

                Model.QueueBind(queue, exchange, routeKey);
            }
        }

        public void Consume(EventHandler<BasicDeliverEventArgs> eventHandler,string queue,bool autoAct = true)
        {
            var consumer = new EventingBasicConsumer(Model);
            consumer.Received += eventHandler;
            Model.BasicConsume(queue: queue,
                                 autoAck: autoAct,
                                 consumer: consumer);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            Publish(body);
        }
        public void Publish(byte[] body)
        {
            var prop = Model.CreateBasicProperties();
            prop.Persistent = true;

            Model.BasicPublish(exchange: CONSTS.exchangeProducer,
                                 routingKey: CONSTS.routekey,
                                 basicProperties: prop,
                                 body: body);
        }

        public void Dispose()
        {
            Connection.Dispose();
            Model.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
