using GildedRose;
using GildedRose.Models;

namespace GildedRoseTests;

public class UpdateQualityTests
{
    private static Item Make(string name, int sellIn, int quality) => new() { Name = name, SellIn = sellIn, Quality = quality };

    private static Item RunOnce(Item item)
    {
        List<Item> items = [ item ];
        var app = new GildedRoseApp();
        app.UpdateQuality(items);
        return items[0];
    }

    [Fact]
    public void NormalItem_DegradesBy1_BeforeSellDate()
    {
        var result = RunOnce(Make("Normal Apple Pie", 10, 20));
        Assert.Equal(19, result.Quality);
        Assert.Equal(9, result.SellIn);
    }

    [Theory]
    [InlineData(0, 10, 9)]   // at 0 quality stays 0, sellIn decrements by 1
    [InlineData(0, 0, -1)]   // at 0 quality after sell date stays 0, sellIn decrements by 1 
    [InlineData(1, 0, -1)]   // at 1 quality after sell date clamps at 0
    public void NormalItem_QualityNeverNegative(int startQuality, int startSellIn, int expectedSellIn)
    {
        var result = RunOnce(Make("Normal Dirty Chai Latte", startSellIn, startQuality));
        Assert.True(result.Quality >= 0);
        Assert.Equal(expectedSellIn, result.SellIn);
    }

    [Fact]
    public void NormalItem_DegradesBy2_AfterSellDate()
    {
        var result = RunOnce(Make("Normal Cheddar", 0, 7));
        Assert.Equal(5, result.Quality);
        Assert.Equal(-1, result.SellIn);
    }

    [Fact]
    public void AgedBrie_IncreasesBy1_BeforeSellDate()
    {
        var result = RunOnce(Make("Aged Brie", 2, 0));
        Assert.Equal(1, result.Quality);
        Assert.Equal(1, result.SellIn);
    }

    [Fact]
    public void AgedBrie_IncreasesBy2_AfterSellDate()
    {
        var result = RunOnce(Make("Aged Brie", 0, 10));
        Assert.Equal(12, result.Quality);
        Assert.Equal(-1, result.SellIn);
    }

    [Fact]
    public void AgedBrie_CappedAt50_From50()
    {
        var result = RunOnce(Make("Aged Brie", 5, 50));
        Assert.Equal(50, result.Quality);
        Assert.Equal(4, result.SellIn);
    }

    [Fact]
    public void AgedBrie_CappedAt50_From49_OnSellDate()
    {
        var result = RunOnce(Make("Aged Brie", 0, 49));
        Assert.Equal(50, result.Quality);
        Assert.Equal(-1, result.SellIn);
    }

    [Fact]
    public void Backstage_IncreaseBy1_MoreThan10Days()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 15, 20));
        Assert.Equal(21, result.Quality);
        Assert.Equal(14, result.SellIn);
    }

    [Fact]
    public void Backstage_IncreaseBy2_At10Days()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 10, 20));
        Assert.Equal(22, result.Quality);
        Assert.Equal(9, result.SellIn);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    public void Backstage_IncreaseBy3_At5OrLessDays(int startSellIn)
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", startSellIn, 20));
        Assert.Equal(23, result.Quality);
        Assert.Equal(startSellIn - 1, result.SellIn);
    }

    [Fact]
    public void Backstage_QualityDropsToZero_OnSellDate()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 0, 35));
        Assert.Equal(0, result.Quality);
        Assert.Equal(-1, result.SellIn);
    }

    [Fact]
    public void Backstage_QualityDropsToZero_AfterSellDate()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", -1, 35));
        Assert.Equal(0, result.Quality);
        Assert.Equal(-2, result.SellIn);
    }

    [Fact]
    public void Backstage_CappedAt50_At10Days_From49()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 10, 49));
        Assert.Equal(50, result.Quality);
        Assert.Equal(9, result.SellIn);
    }

    [Fact]
    public void Backstage_CappedAt50_At5Days_From49()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 5, 49));
        Assert.Equal(50, result.Quality);
        Assert.Equal(4, result.SellIn);
    }

    [Fact]
    public void Backstage_CappedAt50_From50()
    {
        var result = RunOnce(Make("Backstage passes to a TAFKAL80ETC concert", 5, 50));
        Assert.Equal(50, result.Quality);
        Assert.Equal(4, result.SellIn);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(5)]
    public void Sulfuras_DoesNotChange(int startSellIn)
    {
        var result = RunOnce(Make("Sulfuras, Hand of Ragnaros", startSellIn, 80));
        Assert.Equal(80, result.Quality);
        Assert.Equal(startSellIn, result.SellIn);
    }

}
