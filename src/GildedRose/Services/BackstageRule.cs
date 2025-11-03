using GildedRose.Models;


namespace GildedRose.Services
{
    public class BackstageRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 10 && item.Quality < 50)
                {
                    item.Quality++;
                }
                if (item.SellIn < 5 && item.Quality < 50)
                {
                    item.Quality++;
                }
            }
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
