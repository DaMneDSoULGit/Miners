using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinerServer.MapObjects;

namespace MinerServerUnitTests.MapObjects
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void PointRangeTest()
        {
            Point p1 = new Point(3, 4);
            Point p2 = new Point(1, 2);

            double range = Point.Range(p1, p2);

            Assert.AreEqual(range, Math.Sqrt(8));
            Assert.AreEqual(p1.RangeTo(p2), range);

        }

        [TestMethod]
        public void RangeToTest()
        {
            Point p1 = new Point(3, 4);
            Point p2 = new Point(1, 2);
            Assert.IsFalse(Point.IsInRangeLow(p1, p2, 3));//2.8
            Assert.IsTrue(Point.IsInRangeLow(p1, p2, 2));

            for (double i = 0; i < 30; i += 0.1)
            {
                Assert.AreEqual(Point.IsInRangeLow(p1, p2, i), Point.IsInRangeLong(p1, p2, i));
            }
        }
    }
}
