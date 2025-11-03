using GildedRose.Models;

namespace GildedRose.Services;

public static class ItemClassifier
{
    public static ItemType Classify(Item item)
    {
        var name = item.Name;
        if (name.StartsWith(ItemNames.Sulfuras)) return ItemType.Sulfuras;
        if (name == ItemNames.AgedBrie) return ItemType.AgedBrie;
        if (name.StartsWith(ItemNames.Backstage)) return ItemType.Backstage;
        if (name.StartsWith(ItemNames.Conjured)) return ItemType.Conjured;
        return ItemType.Normal;
    }
}