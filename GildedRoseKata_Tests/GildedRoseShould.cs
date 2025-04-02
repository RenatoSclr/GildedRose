using GildedRoseKata;

namespace GildedRoseKata_Tests
{
    public class GildedRoseShould
    {
        private static IList<Item> GetItems()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }


        [Fact]
        public void Test_for_one_day()
        {
            var expectedQuality = new int[] { 19, 1, 6, 80, 80, 21, 50, 50, 5 };
            var expectedSellIn = new int[] { 9, 1, 4, 0, -1, 14, 9, 4, 2 };

            var items = GetItems();

            int days = 1;

            GildedRose gildedRose = new GildedRose(items);

            for (int i = 0; i < days; i++)
            {
                gildedRose.UpdateQuality();

                var actualQuality = gildedRose.Items.Select(item => item.Quality).ToArray();

                Assert.Equal(expectedQuality, actualQuality);
                var actualSellIn = gildedRose.Items.Select(item => item.SellIn).ToArray();

                Assert.Equal(expectedSellIn, actualSellIn);
            }
        }


        [Fact]
        public void Be_Same_Result_Between_GildedRose_and_GildedRoseGolden_with_100_days()
        {
            var itemsGildedRose = GetItems();
            var itemsGildedRoseGolden = GetItems();

            int days = 100;

            GildedRose gildedRose = new GildedRose(itemsGildedRose);
            GildedRoseGolden gildedRoseGolden = new GildedRoseGolden(itemsGildedRoseGolden);

            for (int i = 0; i < days; i++)
            {
                gildedRose.UpdateQuality();
                gildedRoseGolden.UpdateQuality();

                var gildedRoseQuality = gildedRose.Items.Select(item => item.Quality).ToArray();
                var gildedRoseGoldenQuality = gildedRoseGolden.Items.Select(item => item.Quality).ToArray();

                Assert.Equal(gildedRoseQuality, gildedRoseGoldenQuality);


                var gildedRoseSellIn = gildedRose.Items.Select(item => item.SellIn).ToArray();
                var gildedRoseGoldenSellIn = gildedRoseGolden.Items.Select(item => item.SellIn).ToArray();

                Assert.Equal(gildedRoseSellIn, gildedRoseGoldenSellIn);
            }
        }
    }
}
