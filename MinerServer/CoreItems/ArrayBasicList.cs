#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MinerServer.Helpers;

#endregion

namespace MinerServer.CoreItems
{
    public class ArrayBasicList<T> : IObjectContainer<T>
    {
        private int capasity = 100;
        private ArrayContainerObject<T>[] itemsArray = new ArrayContainerObject<T>[100];
        private int lastiterator;

        public ArrayBasicList()
        {
            for (int i = 0; i < 100; i++)
            {
                itemsArray[i] = new ArrayContainerObject<T>();
            }
        }

        #region IObjectContainer<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return (itemsArray.Where(containerObject => !containerObject.Removed).Select(
                containerObject => containerObject.Item)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (lastiterator >= capasity) lastiterator = 0;
            ArrayContainerObject<T> container = itemsArray[lastiterator];
            if (container.Removed)
            {
                container.Asign(item);
                lastiterator++;
            }
            else
            {
                lastiterator++;
                Add(item);
            }
        }

        public bool Contains(T item)
        {
            return itemsArray.Where(x => !x.Removed).Any(x => ReferenceEquals(item, x.Item));
        }

        public void Trim()
        {
        }

        public void Remove(Func<T, bool> condition)
        {
            itemsArray.Where(x => condition(x.Item)).Invoke(x => x.Remove());
        }

        public void Remove(T item)
        {
            itemsArray.First(x => ReferenceEquals(x.Item, item)).Remove();
        }

        public void Clear()
        {
            itemsArray = new ArrayContainerObject<T>[100];
            capasity = 100;
            lastiterator = 0;
        }

        #endregion

        private void Expand()
        {
            throw new NotImplementedException();
        }

        #region Nested type: ArrayContainerObject

        private class ArrayContainerObject<TItem>
        {
            public ArrayContainerObject()
            {
                Removed = true;
            }

            public TItem Item { get; private set; }
            public bool Removed { get; private set; }

            public void Remove()
            {
                Removed = true;
            }

            public void Asign(TItem initem)
            {
                Item = initem;
                Removed = false;
            }
        }

        #endregion
    }
}