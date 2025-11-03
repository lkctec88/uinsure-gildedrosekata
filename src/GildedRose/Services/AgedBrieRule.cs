using GildedRose.Models;


namespace GildedRose.Services
{
    public class AgedBrieRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;

            QualityHelper.Increase(item, 1);
            if (item.SellIn < 0)
            {
                QualityHelper.Increase(item, 1);
            }
        }
    }
}
