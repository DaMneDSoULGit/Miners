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
            List<Vector> vectors = new List<Vector>
                                       {
                                           Vector.FromAngle(0),
                                           Vector.FromAngle(45),
                                           Vector.FromAngle(90),
                                           Vector.FromAngle(120),
                                           Vector.FromAngle(180),
                                           Vector.FromAngle(270),
                                           Vector.FromAngle(360),

                                       };

            vectors.ForEach(x=>Console.WriteLine(x));
            Console.ReadLine();
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
