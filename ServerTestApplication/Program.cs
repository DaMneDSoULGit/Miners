using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreGameObjects;
using MinerServer.CoreItems;
using MinerServer.Helpers;

namespace ServerTestApplication
{
    class Team : IParent<Player>
    {
        public IObjectContainer<Player> ChildList { get; set; }
    }

    class Player : ChildBase<Team>
    {
        public Player(GameContainer container, Team parent) : base(container, parent)
        {
        }
        
        public override int EveryTickNumber
        {
            get { throw new NotImplementedException(); }
        }

        public override void OnGameObjectTick()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main()
        {
            Test(new ArrayBasicList<TestObject>());
            Test(new DynamicList<TestObject>());
            Console.ReadLine();
        }

        private static void Test(IObjectContainer<TestObject> test)
        {
            IObjectContainer<TestObject> dl = test;

            TestObject[] randoms = new TestObject[100];

            for (int i = 0; i < randoms.GetLength(0); i++)
            {
                randoms[i] = new TestObject("sadsd" + i.ToString());
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            DebugHelper.CheckTimeSpan(() =>
                                          {
                                              for (int j = 0; j < 10000; j++)
                                              {
                                                  for (int i = 0; i < 98; i++)
                                                  {
                                                      dl.Add(randoms[i]);
                                                  }

                                                  for (int i = 0; i < 98; i++)
                                                  {
                                                      dl.Remove(randoms[i]);
                                                  }
                                                  dl.Trim();
                                              }
                                          }, x =>
                                                 {
                                                     Console.WriteLine(dl.ToString());
                                                     Console.WriteLine(x.ToString());
                                                 });

        }
    }

    internal class TestObject
    {
        private string p;
        public TestObject(string item)
        {
            p = item;
        }
        public override string ToString()
        {
            return p;
        }
    }
}
