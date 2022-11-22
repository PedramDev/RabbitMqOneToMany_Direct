using Microsoft.Extensions.DependencyInjection;
using Consumer1;
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

        Console.WriteLine("## 1 Consumer 1 ##");
        Console.WriteLine("## One2One (CONSTS.Queue3) ##");
        Console.WriteLine("## One2Many (CONSTS.Queue1) ##");
        Console.ReadLine();
    }
}