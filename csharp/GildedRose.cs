using System.Collections.Generic;
using csharp.Items;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (!(item is AgedBrie) 
                    && !(item is Sulfuras) 
                    && !(item is Backstagepasses) && item.Quality > 0)
                {
                            item.Quality = item.Quality - 1;
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item is Backstagepasses)
                        {
                            if (item.SellIn < 11 && item.Quality < 50)
                            {
                                    item.Quality = item.Quality + 1;
                            }

                            if (item.SellIn < 6 && item.Quality<50)
                            {
                                    item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }

                if (!(item is Sulfuras))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn >= 0) continue;

                if (!(item is AgedBrie))
                {
                    if (!(item is Backstagepasses) && !(item is Sulfuras) && item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
