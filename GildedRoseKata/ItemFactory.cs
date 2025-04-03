using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemFactory
    {
        private readonly ItemModifier _itemModifier;
        private readonly Dictionary<string, IUpdateItem> _strategies;

        public ItemFactory(ItemModifier itemModifier)
        {
            _itemModifier = itemModifier;
            _strategies = new Dictionary<string, IUpdateItem>
            {
                { "Aged Brie", new AgedBrieItem(_itemModifier) },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesItem(_itemModifier) }
            };
        }

        public IUpdateItem GetStrategy(Item item)
        {
            return _strategies.TryGetValue(item.Name, out var strategy)
                ? strategy
                : new NormalItem(_itemModifier);
        }
    }
}
