using NUnit.Framework;

namespace TestProjectShelf
{
    public class Tests
    {
        [Test]
        public void ShelfCanAcceptAndReturnItem()
        {
            Shelf shelf = new Shelf();
            shelf.Put("Orange");
            Assert.AreEqual(true, shelf.Take("Orange"));
        }

        [Test]
        public void ShelfCanAcceptAndReturnItemNull()
        {
            Shelf shelf = new Shelf();
            shelf.Put(null);
            Assert.AreEqual(false, shelf.Take(null));
        }

        [Test]
        public void ShelfCanAcceptAndReturnItemEmpty()
        {
            Shelf shelf = new Shelf();
            shelf.Put(string.Empty);
            Assert.AreEqual(false, shelf.Take(string.Empty));
        }

        [Test]
        public void ShelfCanAcceptAndReturnItemRemove()
        {
            Shelf shelf = new Shelf();
            shelf.Put("Orange");
            shelf.Take("Orange");
            Assert.AreEqual(false, shelf.Take("Orange"));
        }
    }
}