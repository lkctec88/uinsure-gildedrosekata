using GildedRose.Models;

namespace GildedRose.Services
{
    public class ConjuredRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            // Age one day
            item.SellIn--;

            // Conjured items degrade twice as fast as normal
            QualityHelper.Decrease(item, 2);
            if (item.SellIn < 0)
            {
                QualityHelper.Decrease(item, 2);
            }
        }
    }
}
