using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }

        [Test]
        public void UpdateQuality_IfItemNotOnWhiteList_QualityIsDecremented()
        {
            var items = new List<Item> {new Item {Name = "Some Random Name", Quality = 4, SellIn = 5}};
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(3, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_IfItemNotOnWhiteList_QualityIsDecremented_ifsellinlessthanzero_itemqualitydecrementedagain()
        {
            var items = new List<Item> { new Item { Name = "Some Random Name", Quality = 4, SellIn = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_IfIfItemNotOnWhiteList_SellinIsDecremented()
        {
            var items = new List<Item> { new Item { Name = "Some Random Name", Quality = 4, SellIn = 5 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(4, items[0].SellIn);
        }

        ///<remarks>
        /// Is a whitelisted book
        /// quality &lt;50
        /// quality +1
        /// item selling &gt;0
        ///</remarks>
        [Test]
        public void  UpdateQuality_IfItemOnWhiteList_ItemQualityLessThan50_qweqwe()
        {
            var itemWhiteList= new List<Item>
            {
                 new Item { Name = "Aged Brie", Quality = 3, SellIn = 5 }
                ,new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 6, SellIn = 5 }
                ,new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 2, SellIn = 5 }
            };
            var itemBeingProcessed = new List<Item> { new Item { Name = "Aged Brie", Quality = 4, SellIn = 5 } };
            GildedRose app = new GildedRose(itemBeingProcessed);
            app.UpdateQuality();
            Assert.AreEqual(5, itemBeingProcessed[0].Quality);
        }
        ///<remarks>
        /// Is a whitelisted book
        /// quality &lt;50
        /// quality +1
        /// if item.name!="Sulfuras, hand of ragnaros"
        /// sellin=sellin-1
        /// if selling &lt;0 
        /// and item quality &lt;50 
        /// add 1 to item quality
        ///</remarks>
        [Test]
        public void UpdateQuality_IfItemOnWhiteList_ItemQualitwyLessThan50_qweqwe()
        {
            var itemWhiteList = new List<Item>
            {
                new Item { Name = "Aged Brie", Quality = 3, SellIn = 5 }
                ,new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 6, SellIn = 5 }
                ,new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 2, SellIn = 5 }
            };
            var itemBeingProcessed = new List<Item> { new Item { Name = "Aged Brie", Quality = 4, SellIn = 0 } };
            GildedRose app = new GildedRose(itemBeingProcessed);
            app.UpdateQuality();
            Assert.AreEqual(6, itemBeingProcessed[0].Quality);
        }

        [Test]
        public void UpdateQuality_IfItemOnWhiteList_ItemQualitwyLessThan52_qweqwe()
        {
            var itemWhiteList = new List<Item>
            {
                new Item { Name = "Aged Brie", Quality = 3, SellIn = 5 }
                ,new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 6, SellIn = 10 }
                ,new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 2, SellIn = 5 }
            };
            var itemBeingProcessed = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 4, SellIn = 0 } };
            GildedRose app = new GildedRose(itemBeingProcessed);
            app.UpdateQuality();
            Assert.AreEqual(0, itemBeingProcessed[0].Quality);
        }


    }
}
