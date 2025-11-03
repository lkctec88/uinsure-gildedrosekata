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
        private static readonly NormalRule Normal = new();
        private static readonly AgedBrieRule Brie = new();
        private static readonly BackstageRule Backstage = new();
        private static readonly SulfurasRule Sulfuras = new();
        private static readonly ConjuredRule Conjured = new();

        public static IUpdateRule For(Item item) => ItemClassifier.Classify(item) switch
        {
            ItemType.Sulfuras => Sulfuras,
            ItemType.AgedBrie => Brie,
            ItemType.Backstage => Backstage,
            ItemType.Conjured => Conjured,
            _ => Normal
        };
    }
}
