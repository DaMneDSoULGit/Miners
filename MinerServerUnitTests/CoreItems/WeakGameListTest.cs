using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinerServer.CoreItems;

namespace MinerServerUnitTests.CoreItems
{
    [TestClass]
    public class WeakGameListTest
    {
        [TestMethod]
        public void ListTest()
        {
            var list = new WeakGameList<object> { new object(), new object(), new object() };
            Assert.AreEqual(list.Count(), list.Count);
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            list.Trim();

            Assert.AreEqual(list.Count(), 0);
            Assert.AreEqual(list.Count, 0);

        }
    }
}
