using Microsoft.Extensions.DependencyInjection;
using Producer;

internal sealed class Program
{
    private static async Task Main()
    {
        var application = AppModule.Initialize();

        Console.WriteLine("## Producer ##");

        while (true)
        {
            Console.WriteLine("## Enter Your Message : ##");
            var message = Console.ReadLine();

            if (message != null)
            {
                Console.WriteLine("## OneToOne = 1 : ##");
                Console.WriteLine("## OneToMany = 2 : ##");

                var whichRabbit = Console.ReadLine();
                switch (whichRabbit)
                {
                    case "1":
                        application.GetRequiredService<RabbitServiceForOneToOne>().Publish(message);
                        break;

                    case "2":
                        application.GetRequiredService<RabbitServiceForOneToMany>().Publish(message);
                        break;

                    default:
                        Console.WriteLine("###################");
                        continue;
                }

                Console.WriteLine(" [x] Sent {0}", message);
                await Task.Delay(millisecondsDelay: 5000);
            }
        }

    }
}