using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinerServer.CoreItems;

namespace MinerServerUnitTests.CoreItems
{
    [TestClass]
    public class GameListTest
    {
        [TestMethod]
        public void ListTest()
        {
            var simplelist = new List<object>();

            object item1 = new object();
            object item2 = new object();
            object item3 = new object();
            object item4NotContains = new object();

            simplelist.Add(item1);
            simplelist.Add(item2);
            simplelist.Add(item3);

            var gameList = new GameList<object>();

            foreach (object o in simplelist)
            {
                gameList.Add(o);
            }

            foreach (object o in gameList)
            {
                Assert.IsTrue(simplelist.Contains(o));
            }

            foreach (object o in simplelist)
            {
                Assert.IsTrue(gameList.Contains(o));
            }

            Assert.IsFalse(gameList.Contains(item4NotContains));
            Assert.AreEqual(gameList.Count, 3);

            gameList.Remove(x => ReferenceEquals(x, item2));
            Assert.IsFalse(gameList.Contains(item2));
            Assert.AreEqual(gameList.Count, 2);


            gameList.Clear();
            Assert.AreEqual(gameList.Count, 0);
        }
    }
}
