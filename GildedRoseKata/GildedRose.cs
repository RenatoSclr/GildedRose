using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGES = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

        public IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name == SULFURAS)
                {
                    continue;
                }

                item.SellIn -= 1;

                switch (item.Name)
                {
                    case AGED_BRIE:
                        UpdateAgedBrieItem(item);
                        break;
                    case BACKSTAGES:
                        UpdateBackstagePassesItem(item);
                        break;
                    default:
                        UpdateNormalItem(item);
                        break;
                }
            }
        }

        private static void UpdateAgedBrieItem(Item item)
        {
            if (item.Quality < 50)
            {
                IncreaseQuality(item);
            }


            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    IncreaseQuality(item);
                }
            }
        }

        private static void UpdateBackstagePassesItem(Item item)
        {
            if (item.Quality < 50)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 10)
            {
                if (item.Quality < 50)
                {
                    IncreaseQuality(item);
                }
            }

            if (item.SellIn < 5)
            {
                if (item.Quality < 50)
                {
                    IncreaseQuality(item);
                }
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private static void UpdateNormalItem(Item item)
        {
            if (item.Quality > 0)
            {
                DecreaseQuality(item);
            }

            if (item.SellIn < 0)
            {

                if (item.Quality > 0)
                {
                    DecreaseQuality(item);
                }

            }
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality -= 1;
        }
    }
}
