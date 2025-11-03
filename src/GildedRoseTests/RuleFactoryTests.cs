using GildedRose.Models;
using GildedRose.Services;

namespace GildedRoseTests;

public class RuleFactoryTests
{
    private static IUpdateRule Resolve(string name) => RuleFactory.For(new Item { Name = name, SellIn = 0, Quality = 0 });

    [Fact]
    public void Maps_Sulfuras_To_SulfurasRule()
    {
        Assert.IsType<SulfurasRule>(Resolve(ItemNames.Sulfuras));
    }

    [Fact]
    public void Maps_AgedBrie_To_AgedBrieRule()
    {
        Assert.IsType<AgedBrieRule>(Resolve(ItemNames.AgedBrie));
    }

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert")]
    [InlineData("Backstage passes - Any Band")] 
    public void Maps_BackstagePrefix_To_BackstageRule(string name)
    {
        Assert.IsType<BackstageRule>(Resolve(name));
    }

    [Theory]
    [InlineData("Conjured Mana Cake")]
    [InlineData("Conjured Something Else")]
    public void Maps_ConjuredPrefix_To_ConjuredRule(string name)
    {
        Assert.IsType<ConjuredRule>(Resolve(name));
    }

    [Theory]
    [InlineData("Normal Item")]
    [InlineData("+5 Dexterity Vest")]
    [InlineData("Elixir of the Mongoose")]
    public void Maps_Unknown_To_NormalRule(string name)
    {
        Assert.IsType<NormalRule>(Resolve(name));
    }
}
