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
                        new AgedBrieItem().UpdateItem(item);
                        break;
                    case BACKSTAGES:
                        new BackstagePassesItem().UpdateItem(item);
                        break;
                    default:
                        new NormalItem().UpdateItem(item);
                        break;
                }
            }
        }
    }
}
