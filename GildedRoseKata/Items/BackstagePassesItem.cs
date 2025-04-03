using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Items
{
    public class BackstagePassesItem(ItemModifier _itemModifier) : IUpdateItem
    {
        public void UpdateItem(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            _itemModifier.IncreaseQuality(item);

            if (item.SellIn < 10) _itemModifier.IncreaseQuality(item);

            if (item.SellIn < 5) _itemModifier.IncreaseQuality(item);
        }
    } 
}

