using GildedRose.Models;


namespace GildedRose.Services
{
    public class BackstageRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;

            if (item.SellIn >= 0)
            {
                QualityHelper.Increase(item, 1);
                if (item.SellIn < 10)
                {
                    QualityHelper.Increase(item, 1);
                }
                if (item.SellIn < 5)
                {
                    QualityHelper.Increase(item, 1);
                }
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
