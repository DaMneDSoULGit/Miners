using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;
using MinerServer.Helpers;

namespace MineServerTestProject
{
    [TestClass]
    public class CoreItemsTest
    {
        [TestMethod]
        public void PositionTest()
        {
            var pos = Point.FromXY(5, 6);
            Assert.AreEqual(5, pos.X, 0.000001);
            Assert.AreEqual(6, pos.Y, 0.000001);
        }

        [TestMethod]
        public void VectorTest()
        {
            var po1 = Point.FromXY(5, 6);
            var po2 = Point.FromXY(6, 5);
            var vect = po1 - po2;
            Assert.IsTrue(po2 == po1 - vect);

            var vect2 = Vector.FromAngle(90);
            Assert.IsTrue(vect2 == Vector.FromXY(1, 0));
            vect2 = Vector.FromAngle(180);
            Assert.IsTrue(vect2 == Vector.FromXY(0, 1));

        }

        class TestParent : IParent<TestChild>
        {
            public IObjectContainer<TestChild> ChildList { get; set; }

            public TestParent()
            {
                ChildList = new DynamicList<TestChild>();
            }
        }

        class TestChild : ChildBase<TestParent>
        {
            public TestChild(GameContainer container, TestParent parent)
                : base(container, parent)
            {
            }

            public override int EveryTickNumber
            {
                get { return 1; }
            }

            public override void OnGameObjectTick()
            {
                //nothing
            }
        }

        [TestMethod]
        public void HierarhyTest()
        {
            WeakObject<GameContainer> weakContainer = new WeakObject<GameContainer>(new GameContainer());
            WeakObject<TestParent> weakParent = new WeakObject<TestParent>(new TestParent());
            WeakObject<TestChild> weakChild = new WeakObject<TestChild>(new TestChild(weakContainer.Value, weakParent.Value));
            weakParent.Value.ChildList.Add(weakChild.Value);

            Assert.IsTrue(weakParent.Value.ChildList.Contains(weakChild.Value));
            Assert.AreEqual(weakChild.Value.Parent, weakParent.Value);
            Assert.AreEqual(weakChild.Value.GameContainer, weakContainer.Value);

            DebugHelper.FullGCCollect();
            Assert.IsNull(weakParent.Value);
            Assert.IsNull(weakContainer.Value);
            Assert.IsNull(weakChild.Value);
        }

    }
}
