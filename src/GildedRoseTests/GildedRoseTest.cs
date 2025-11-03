
using GildedRose;
using GildedRose.Models;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        List<Item> items = [ new Item { Name = "foo", SellIn = 0, Quality = 0 } ];
        GildedRoseApp app = new();
        app.UpdateQuality(items);
        Assert.Equal("foo", items[0].Name);
    }
}
