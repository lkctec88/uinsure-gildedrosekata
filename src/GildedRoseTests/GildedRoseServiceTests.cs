using GildedRose.Models;
using GildedRose.Services;

namespace GildedRoseTests;

public class GildedRoseServiceTests
{
    [Fact]
    public void UpdateQuality_AppliesRules_AndAgesOnce_PerItem()
    {
        var items = new List<Item>
        {
            new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }, // normal
            new() { Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0 },
            new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }, // normal
            new() { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 },
            new() { Name = ItemNames.Backstage, SellIn = 15, Quality = 20 },
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        IGildedRoseService service = new GildedRoseService();
        service.UpdateQuality(items);

        // Non-Sulfuras items age once (SellIn--)
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(1, items[1].SellIn);
        Assert.Equal(4, items[2].SellIn);
        Assert.Equal(14, items[4].SellIn);
        Assert.Equal(2, items[5].SellIn);

        // Sulfuras unchanged
        Assert.Equal(0, items[3].SellIn);
        Assert.Equal(80, items[3].Quality);
    }
}
