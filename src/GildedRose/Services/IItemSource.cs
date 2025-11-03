using GildedRose.Models;

namespace GildedRose.Services;

public interface IItemSource
{
    IList<Item> GetInitialItems();
}