#region

using System.Collections;
using System.Linq;
using MinerServer.CoreItems;

#endregion

namespace MinerServer.CoreGameObjects
{
    internal class VisibilityMap
    {
        private readonly VisibilityLine[] gameVisibilityMap;

        private VisibilityMap()
        {
            gameVisibilityMap = new VisibilityLine[100];
            for (int i = 0; i < 100; i++)
            {
                gameVisibilityMap[i] = new VisibilityLine();
            }
            Capacity = 100;
        }

        private int Capacity { get; set; }

        private int LastIterator { get; set; }

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

        #region Nested type: VisibilityLine

        private class VisibilityLine
        {
            private bool deleted;
            private int index = -1;
            private BitArray visibilityMap = new BitArray(100);
            public WeakObject<GameObject> Owner { get; private set; }

            private bool IsValid
            {
                get { return !deleted && Owner != null && index != -1; }
            }

            public void Initialize(GameObject obj)
            {
                Owner = new WeakObject<GameObject>(obj);
                index = obj.Index;
            }

            public void Delete()
            {
                deleted = true;
            }
        }

        #endregion
    }
}