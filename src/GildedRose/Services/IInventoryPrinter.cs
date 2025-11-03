using GildedRose.Models;

namespace GildedRose.Services;

public interface IInventoryPrinter
{
    void Print(IEnumerable<Item> items, TextWriter writer, int day);
}