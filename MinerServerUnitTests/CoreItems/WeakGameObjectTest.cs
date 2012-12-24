using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinerServer.CoreItems;

namespace MinerServerUnitTests.CoreItems
{
    [TestClass]
    public class WeakGameObjectTest
    {
        [TestMethod]
        public void CoreTest()
        {
            var testObj = new WeakGameObject<object>(new object());
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Assert.IsNull(testObj.GetItem);
        }
    }
}
