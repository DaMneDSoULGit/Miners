using System;
using System.Collections.Generic;
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
            var list = new WeakGameList<object>();
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

        }
    }
}
