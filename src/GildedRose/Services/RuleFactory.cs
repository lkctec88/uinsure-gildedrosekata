using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Services
{
    public static class RuleFactory
    {
        public static IUpdateRule For(Item item) =>
        item.Name switch
        {
            var n when n == ItemNames.Sulfuras => new SulfurasRule(),
            var n when n == ItemNames.AgedBrie => new AgedBrieRule(),
            var n when n.StartsWith(ItemNames.Backstage) => new BackstageRule(),
            var n when n.StartsWith(ItemNames.Conjured) => new ConjuredRule(),
            _ => new NormalRule()
        };
    }
}
