using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace KataGildedRose.Tests {
    public class GildedRoseTest {
        private static List<Item> _items;

        [Fact]
        public void GuildedRose_Check_FirstElementName_Ok() {
            var app = CreateGuildedRose("Normal item", 0, 0);
            app.UpdateQuality();
            Assert.Equal("Normal item", _items[0].Name);
        }

        private static GildedRose CreateGuildedRose(string name, int sellIn, int quality) {
            _items = new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                }
            };
            var app = new GildedRose(_items);
            return app;
        }

        [Fact(Skip = "Not implemented")]
        public void GuildedRose_Check_Item_With_Negative_Quality_NotOk() {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Normal item",
                    SellIn = 0,
                    Quality = -1
                }
            };
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => new GildedRose(items));
        }

        [Fact]
        public void GuildedRose_Check_LowerQuality_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Normal item", 49, 49);
            app.UpdateQuality();
            Assert.Equal(48, _items[0].Quality);
        }

        [Fact]
        public void GuildedRose_Check_LowerSellin_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Normal item", 49, 49);
            app.UpdateQuality();
            Assert.Equal(48, _items[0].SellIn);
        }

        [Fact]
        public void GuildedRose_Check_LowerQuality_TwiceFast_WithSellin_0_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Normal item", 0, 49);
            app.UpdateQuality();
            Assert.Equal(47, _items[0].Quality);
        }

        [Fact]
        public void GuildedRose_Check_Quality_NeverNegative_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Normal item", 2, 0);
            app.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }

        [Fact]
        public void GuildedRose_Check_Quality_When_Selling_0_And_Quality_1_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Normal item", 0, 1);
            app.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }

        [Fact]
        public void GuildedRose_Check_Quality_Incresead_For_AgedBried_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Aged Brie", 47, 47);
            app.UpdateQuality();
            Assert.Equal(48, _items[0].Quality);
        }

        [Fact]
        public void GuildedRose_Check_Quality_Never_Bigger_Than_50_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Aged Brie", 47, 50);
            app.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Check_Quality_Remains_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Sulfuras, Hand of Ragnaros", 47, 47);
            app.UpdateQuality();
            Assert.Equal(47, _items[0].Quality);
        }

        [Fact]
        public void Backstage_Quality_Increase_By_2_When_Sellin_Is_Less_Or_Equal_Than_10_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Backstage passes to a TAFKAL80ETC concert", 10, 47);
            app.UpdateQuality();
            Assert.Equal(49, _items[0].Quality);
        }

        [Fact]
        public void Backstage_Quality_Increase_By_2_When_Sellin_Is_Less_Or_Equal_Than_10_And_Not_More_Than_50_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Backstage passes to a TAFKAL80ETC concert", 10, 49);
            app.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void Backstage_Quality_Increase_By_3_When_Sellin_Is_Less_Or_Equal_Than_5_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Backstage passes to a TAFKAL80ETC concert", 5, 47);
            app.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void Backstage_Quality_Increase_By_3_When_Sellin_Is_Less_Or_Equal_Than_5_And_No_More_Than_50_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Backstage passes to a TAFKAL80ETC concert", 5, 49);
            app.UpdateQuality();
            Assert.Equal(50, _items[0].Quality);
        }

        [Fact]
        public void Backstage_Quality_Drop_to_0_When_Sellin_Is_0_AfterUpdate_Ok() {
            var app = CreateGuildedRose("Backstage passes to a TAFKAL80ETC concert", 0, 47);
            app.UpdateQuality();
            Assert.Equal(0, _items[0].Quality);
        }
    }
}
