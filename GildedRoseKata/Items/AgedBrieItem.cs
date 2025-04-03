namespace GildedRoseKata.Items
{
    public class AgedBrieItem(ItemModifier _itemModifier) : IUpdateItem
    {
        
        public void UpdateItem(Item item)
        {
            _itemModifier.IncreaseQuality(item);

            if (item.SellIn < 0) 
                _itemModifier.IncreaseQuality(item);
        }
    }
}