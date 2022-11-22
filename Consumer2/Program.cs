using Microsoft.Extensions.DependencyInjection;
using Consumer2;
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

        Console.WriteLine("## 2 Consumer 2 ##");
        Console.WriteLine("## One2Many (CONSTS.Queue2) ##");
        Console.ReadLine();
    }
}