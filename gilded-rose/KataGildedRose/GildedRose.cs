using System.Collections.Generic;

namespace KataGildedRose {
    public class GildedRose {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> Items) {
            this._items = Items;
        }

        public void UpdateQuality() {
            for (var i = 0; i < _items.Count; i++) {
                ProcessSelling(i);
                ProcessQuality(i);
            }
        }

        private void ProcessSelling(int i) {
            if (!IsSulfuras(i)) _items[i].SellIn -= 1;
        }

        private void ProcessQuality(int i) {
            if (IsSulfuras(i)) return;
            if (IsAged(i) || IsBack(i)) {
                if (IsSaleDatePassed(i)) {
                    _items[i].Quality = 0;
                    return;
                }
                if (IsBack(i) && IsSelling5DaysOrLess(i)) IncreaseQuality(i, @by: 3);
                else if (IsBack(i) && IsSellin10DayOrLess(i)) IncreaseQuality(i, @by: 2);
                else IncreaseQuality(i);

            }
            else if (IsDataPassedAndNotAged(i)) DecreaseQuality(i, @by: 2);
            else DecreaseQuality(i);
        }

        private bool IsSelling5DaysOrLess(int i) {
            return _items[i].SellIn <= 5;
        }

        private bool IsSaleDatePassed(int i) {
            return _items[i].SellIn < 0;
        }

        private bool IsSellin10DayOrLess(int i) {
            return _items[i].SellIn <= 10;
        }

        private bool IsDataPassedAndNotAged(int i) {
            return !IsAged(i) && IsSaleDatePassed(i);
        }

        private void DecreaseQuality(int i, int @by = 1) {
            if (_items[i].Quality > 0 && !IsSulfuras(i)) _items[i].Quality -= @by;
            if (_items[i].Quality < 0) _items[i].Quality = 0;
        }

        private void IncreaseQuality(int i, int @by = 1) {
            if (_items[i].Quality < 50) _items[i].Quality += @by;
            if (_items[i].Quality > 50) _items[i].Quality = 50;
        }

        private bool IsSulfuras(int i) {
            return _items[i].Name.Equals("Sulfuras, Hand of Ragnaros");
        }

        private bool IsBack(int i) {
            return _items[i].Name.Equals("Backstage passes to a TAFKAL80ETC concert");
        }

        private bool IsAged(int i) {
            return _items[i].Name.Equals("Aged Brie");
        }
    }

    public class Item {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
