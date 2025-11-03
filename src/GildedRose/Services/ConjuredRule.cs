using GildedRose.Models;

namespace GildedRose.Services
{
    internal class ConjuredRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            // SellIn is handled by the caller (GildedRoseOld)
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
