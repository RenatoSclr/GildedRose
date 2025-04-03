namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGES = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;

        public IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name is SULFURAS) continue;

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
                        new NormalItem().UpdateItem(item);
                        break;
                }
            }
        }

        private static void UpdateAgedBrieItem(Item item)
        {
            TryIncreaseQuality(item, 1);
            if (item.SellIn < 0) TryIncreaseQuality(item, 1);
        }

        private static void UpdateBackstagePassesItem(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            TryIncreaseQuality(item, 1);
            if (item.SellIn < 10) TryIncreaseQuality(item, 1);
            if (item.SellIn < 5) TryIncreaseQuality(item, 1);
        }

        private static void TryIncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(item.Quality + amount, MAX_QUALITY);
        }
    }
}
