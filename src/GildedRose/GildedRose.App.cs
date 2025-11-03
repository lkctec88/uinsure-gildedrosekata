using GildedRose.Models;
using GildedRose.Services;

namespace GildedRose;

public class GildedRoseApp
{

    public void UpdateQuality(IList<Item> items)
    {
        foreach (var item in items)
        {
            if (item.Name == ItemNames.Sulfuras) continue;

            item.SellIn--;

            switch (item.Name)
            {
                case ItemNames.AgedBrie:
                    new AgedBrieRule().UpdateItem(item);
                    break;
                case var n when n.StartsWith(ItemNames.Backstage):
                    new BackstageRule().UpdateItem(item);
                    break;
                case var n when n.StartsWith(ItemNames.Conjured):
                    new ConjuredRule().UpdateItem(item);
                    break;
                default:
                    new NormalRule().UpdateItem(item);
                    break;
            }
        }
    }
}
