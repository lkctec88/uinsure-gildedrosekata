using GildedRose.Models;


namespace GildedRose.Services
{
    public class AgedBrieRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
