namespace GildedRoseKata
{
    public class ItemModifier
    {
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;

        public void IncreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Min(item.Quality + amount, MAX_QUALITY);
        }

        public void DecreaseQuality(Item item, int amount = 1)
        {
            item.Quality = Math.Max(item.Quality - amount, MIN_QUALITY);
        }

        public void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}
