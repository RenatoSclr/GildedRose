using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class BackstagePassesItem : IUpdateItem
    {
        public void UpdateItem(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            item.Quality = Math.Min(item.Quality + 1, 50);

            if (item.SellIn < 10) item.Quality = Math.Min(item.Quality + 1, 50);

            if (item.SellIn < 5) item.Quality = Math.Min(item.Quality + 1, 50);
        }
    } 
}

