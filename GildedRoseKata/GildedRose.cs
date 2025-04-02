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

                if (item.Name == AGED_BRIE)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }


                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }    
                    }
                }

                else if (item.Name == BACKSTAGES)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }

                    if (item.SellIn < 10)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 5)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 0)
                    {
                         item.Quality = 0;
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }

                    if (item.SellIn < 0)
                    {
                      
                        if (item.Quality > 0)
                        {
                            item.Quality -= 1;
                        }
                        
                    }
                }     
            }
        }
    }
}
