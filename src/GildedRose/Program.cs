using GildedRose.Models;
using GildedRose.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSingleton<IGildedRoseService, GildedRoseService>();
        builder.Services.AddSingleton<IItemSource, SeedItemSource>();
        builder.Services.AddSingleton<IInventoryPrinter, ConsoleInventoryPrinter>();
        using var host = builder.Build();

        var service = host.Services.GetRequiredService<IGildedRoseService>();
        var source = host.Services.GetRequiredService<IItemSource>();
        var printer = host.Services.GetRequiredService<IInventoryPrinter>();

        Console.WriteLine("OMGHAI!");

        var items = source.GetInitialItems();

        for (var i = 0; i < 31; i++)
        {
            printer.Print(items, Console.Out, i);
            service.UpdateQuality(items);
        }
    }
}
