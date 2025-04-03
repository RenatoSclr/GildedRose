using GildedRoseKata.Items;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGES = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

        private readonly ItemModifier _itemModifier;
        public IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
            _itemModifier = new ItemModifier();
        }

        public void UpdateQuality()
        {
            var itemModifier = new ItemModifier();
            foreach (Item item in Items)
            {
                if (item.Name is SULFURAS) continue;

               _itemModifier.DecreaseSellIn(item);

                switch (item.Name)
                {
                    case AGED_BRIE:
                        new AgedBrieItem(_itemModifier).UpdateItem(item);
                        break;
                    case BACKSTAGES:
                        new BackstagePassesItem(_itemModifier).UpdateItem(item);
                        break;
                    default:
                        new NormalItem(_itemModifier).UpdateItem(item);
                        break;
                }
            }
        }
    }
}
