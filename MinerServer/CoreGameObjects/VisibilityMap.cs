using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreItems;

namespace MinerServer.CoreGameObjects
{
    class VisibilityMap
    {
        class VisibilityLine
        {
            public WeakObject<GameObject> Owner { get; private set; }
            private int index = -1;
            private BitArray visibilityMap = new BitArray(100);

            public void Initialize(GameObject obj)
            {
                Owner = new WeakObject<GameObject>(obj);
                index = obj.Index;
            }

            private bool deleted;

            public void Delete()
            {
                deleted = true;
            }
            bool IsValid
            {
                get { return !deleted && Owner != null && index != -1; }
            }
        }

        private int Capacity { get; set; }

        private int LastIterator { get; set; }

        private readonly VisibilityLine[] gameVisibilityMap;

        VisibilityMap()
        {
            gameVisibilityMap = new VisibilityLine[100];
            for (int i = 0; i < 100; i++)
            {
                gameVisibilityMap[i] = new VisibilityLine();
            }
            Capacity = 100;
        }

        public void AddObject(GameObject obj)
        {
            if (Capacity >= LastIterator)
            {
                Trim();
                Expand();
            }
            gameVisibilityMap[LastIterator].Initialize(obj);

            LastIterator++;
        }

        private void Expand()
        {
            
        }

        public void Remove(GameObject obj)
        {
            gameVisibilityMap.First(x => ReferenceEquals(x.Owner.Value, obj)).Delete();
        }

        public void Trim()
        {

        }

    }
}
