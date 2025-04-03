namespace GildedRoseKata
{
    public class AgedBrieItem : IUpdateItem
    {
        
        public void UpdateItem(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, 50);

            if (item.SellIn < 0) item.Quality = Math.Min(item.Quality + 1, 50);
        }
    }
}