using Microsoft.Extensions.DependencyInjection;
using Producer;
using Shared;
using Volo.Abp;

internal sealed class Program
{
    private static async Task Main()
    {
        using var application = AbpApplicationFactory.Create<AppModule>(options =>
        {
            options.UseAutofac(); //Autofac integration
        });
        application.Initialize();

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
                        application.ServiceProvider.GetRequiredService<RabbitServiceForOneToOne>().Publish(message);
                        break;

                    case "2":
                        application.ServiceProvider.GetRequiredService<RabbitServiceForOneToMany>().Publish(message);
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