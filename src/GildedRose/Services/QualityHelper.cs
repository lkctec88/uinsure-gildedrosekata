using GildedRose.Models;

namespace GildedRose.Services;

public static class QualityHelper
{
    // Increase quality by amount, capped at 50
    public static void Increase(Item item, int amount = 1)
    {
        if (amount <= 0) return;
        var newValue = item.Quality + amount;
        item.Quality = newValue > 50 ? 50 : newValue;
    }

    // Decrease quality by amount, floored at 0
    public static void Decrease(Item item, int amount = 1)
    {
        if (amount <= 0) return;
        var newValue = item.Quality - amount;
        item.Quality = newValue < 0 ? 0 : newValue;
    }
}