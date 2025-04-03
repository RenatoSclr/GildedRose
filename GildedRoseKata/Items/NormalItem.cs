namespace GildedRoseKata.Items
{
    public class NormalItem(ItemModifier _itemModifier) : IUpdateItem
    {
        public void UpdateItem(Item item)
        {
            _itemModifier.DecreaseQuality(item);

            if (item.SellIn < 0)
            {
                _itemModifier.DecreaseQuality(item);
            }
        }
    }
}

