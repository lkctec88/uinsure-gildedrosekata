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
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            if(item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
