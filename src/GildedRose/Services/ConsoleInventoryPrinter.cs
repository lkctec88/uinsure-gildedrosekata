using GildedRose.Models;

namespace GildedRose.Services;

public class ConsoleInventoryPrinter : IInventoryPrinter
{
    public void Print(IEnumerable<Item> items, TextWriter writer, int day)
    {
        writer.WriteLine($"-------- day {day} --------");
        writer.WriteLine("name, sellIn, quality");
        foreach (var item in items)
        {
            writer.WriteLine(item);
        }
        writer.WriteLine();
    }
}