using GildedRose.Models;
using GildedRose.Services;

namespace GildedRoseTests;

public class RulesTests
{
    private static Item Make(string name, int sellIn, int quality) => new() { Name = name, SellIn = sellIn, Quality = quality };

    // Normal
    [Fact]
    public void NormalRule_BeforeSellDate()
    {
        var item = Make("Normal Widget", 10, 10);
        new NormalRule().UpdateItem(item);
        Assert.Equal(9, item.SellIn);
        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void NormalRule_AfterSellDate_DoubleDecay()
    {
        var item = Make("Normal Widget", 0, 3);
        new NormalRule().UpdateItem(item);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void NormalRule_QualityNotNegative()
    {
        var item = Make("Normal Widget", 0, 0);
        new NormalRule().UpdateItem(item);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    // Aged Brie
    [Fact]
    public void AgedBrie_BeforeSellDate_Increases()
    {
        var item = Make(ItemNames.AgedBrie, 2, 0);
        new AgedBrieRule().UpdateItem(item);
        Assert.Equal(1, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void AgedBrie_AfterSellDate_IncreasesTwice()
    {
        var item = Make(ItemNames.AgedBrie, 0, 10);
        new AgedBrieRule().UpdateItem(item);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(12, item.Quality);
    }

    [Fact]
    public void AgedBrie_CappedAt50()
    {
        var item = Make(ItemNames.AgedBrie, 1, 50);
        new AgedBrieRule().UpdateItem(item);
        Assert.Equal(0, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    // Backstage
    [Fact]
    public void Backstage_MoreThan10Days()
    {
        var item = Make(ItemNames.Backstage, 15, 20);
        new BackstageRule().UpdateItem(item);
        Assert.Equal(14, item.SellIn);
        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void Backstage_At10Days_IncreaseBy2()
    {
        var item = Make(ItemNames.Backstage, 10, 20);
        new BackstageRule().UpdateItem(item);
        Assert.Equal(9, item.SellIn);
        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void Backstage_At5Days_IncreaseBy3()
    {
        var item = Make(ItemNames.Backstage, 5, 20);
        new BackstageRule().UpdateItem(item);
        Assert.Equal(4, item.SellIn);
        Assert.Equal(23, item.Quality);
    }

    [Fact]
    public void Backstage_DropsToZero_AfterConcert()
    {
        var item = Make(ItemNames.Backstage, 0, 35);
        new BackstageRule().UpdateItem(item);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void Backstage_CappedAt50()
    {
        var item = Make(ItemNames.Backstage, 5, 49);
        new BackstageRule().UpdateItem(item);
        Assert.Equal(4, item.SellIn);
        Assert.Equal(50, item.Quality);
    }

    // Sulfuras
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(5)]
    public void Sulfuras_NoChange(int sellIn)
    {
        var item = Make(ItemNames.Sulfuras, sellIn, 80);
        new SulfurasRule().UpdateItem(item);
        Assert.Equal(sellIn, item.SellIn);
        Assert.Equal(80, item.Quality);
    }

    // Conjured
    [Fact]
    public void Conjured_BeforeSellDate_TwiceAsFast()
    {
        var item = Make("Conjured Mana Cake", 3, 6);
        new ConjuredRule().UpdateItem(item);
        Assert.Equal(2, item.SellIn);
        Assert.Equal(4, item.Quality);
    }

    [Fact]
    public void Conjured_AfterSellDate_FourPointsTotal()
    {
        var item = Make("Conjured Mana Cake", 0, 6);
        new ConjuredRule().UpdateItem(item);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(2, item.Quality);
    }
}
