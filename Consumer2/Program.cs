using Microsoft.Extensions.DependencyInjection;
using Consumer2;
using Shared;
internal sealed class Program
{
    private static async Task Main()
    {
        var application = AppModule.Initialize();

        Console.WriteLine("## 2 Consumer 2 ##");
        Console.WriteLine("## One2Many (CONSTS.Queue2) ##");
        Console.ReadLine();
    }
}