using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services
{
    public class GildedRoseService : IGildedRoseService
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                RuleFactory.For(item).UpdateItem(item);
            }
        }
    }
}
