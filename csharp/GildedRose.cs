﻿using System.Collections.Generic;

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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros"  && item.Quality > 0)
                {
                            item.Quality = item.Quality - 1;
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
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

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn >= 0) continue;

                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros" && item.Quality > 0)
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
