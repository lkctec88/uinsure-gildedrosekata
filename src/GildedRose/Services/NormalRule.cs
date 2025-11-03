using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services
{
    public class NormalRule : IUpdateRule
    {
        public void UpdateItem(Item item)
        {
            // Age one day
            item.SellIn--;

            // Decrease quality by 1, then again after sell date
            QualityHelper.Decrease(item, 1);
            if (item.SellIn < 0)
            {
                QualityHelper.Decrease(item, 1);
            }
        }
    }
}
