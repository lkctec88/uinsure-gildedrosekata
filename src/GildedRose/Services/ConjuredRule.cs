using GildedRose.Models;

namespace GildedRose.Services
{
    public class ConjuredRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            // Age one day
            item.SellIn--;

            // Conjured items degrade twice as fast as normal: -2 per day total
            if (item.Quality > 0)
            {
                item.Quality -= 2;
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
