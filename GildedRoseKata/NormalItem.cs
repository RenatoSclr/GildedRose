namespace GildedRoseKata
{
    public class NormalItem : IUpdateItem
    {
        public void UpdateItem(Item item)
        {
            item.Quality = Math.Max(item.Quality - 1, 0);

            if (item.SellIn < 0)
            {
                item.Quality = Math.Max(item.Quality - 1, 0);
            }
        }
    }
}

