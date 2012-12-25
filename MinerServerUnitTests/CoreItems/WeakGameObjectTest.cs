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
            Assert.IsNotNull(testObj.GetItem);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Assert.IsNull(testObj.GetItem);

            var testOb = new WeakGameObject<object>(new object());
            testOb.SetFree();
            Assert.IsNull(testObj.GetItem);
        }
    }
}
