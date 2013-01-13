#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;

#endregion

namespace MinerServer.CoreItems
{
    public class DynamicList<T> : IObjectContainer<T>
    {
        private ListComponent<T> firstItem;

        #region IObjectContainer<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (!iterator.Removed)
                {
                    yield return iterator.Item;
                }
                iterator = iterator.NextElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            firstItem = firstItem == null
                            ? new ListComponent<T>(item)
                            : new ListComponent<T>(item) {NextElement = firstItem};
        }

        public void Clear()
        {
            firstItem = null;
        }

        public bool Contains(T item)
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (!iterator.Removed && ReferenceEquals(iterator.Item, item)) return true;
                iterator = iterator.NextElement;
            }
            return false;
        }

        public void Trim()
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null && iterator.Removed)
            {
                iterator = firstItem = iterator.NextElement;
            }

            iterator = firstItem;
            if (iterator == null) return;
            ListComponent<T> prev = firstItem;
            iterator = prev.NextElement;

            while (iterator != null)
            {
                if (iterator.Removed)
                {
                    iterator = prev.NextElement = iterator.NextElement;
                }
                else
                {
                    iterator = iterator.NextElement;
                    prev = prev.NextElement;
                }
            }
        }

        public void Remove(T item)
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (ReferenceEquals(iterator.Item, item))
                {
                    iterator.Remove();
                    return;
                }
                iterator = iterator.NextElement;
            }
            throw new InstanceNotFoundException();
        }

        public void Remove(Func<T, bool> condition)
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (condition(iterator.Item))
                {
                    iterator.Remove();
                }
                iterator = iterator.NextElement;
            }
        }

        #endregion

        #region Nested type: ListComponent

        private class ListComponent<TItem>
        {
            private readonly TItem listItem;
            public ListComponent<TItem> NextElement;

            public ListComponent(TItem item)
            {
                listItem = item;
            }

            public bool Removed { get; private set; }

            public TItem Item
            {
                get { return listItem; }
            }

            public void Remove()
            {
                Removed = true;
            }
        }

        #endregion

        //public override string ToString()
        //{
        //    StringBuilder stringbuilder = new StringBuilder();
        //    foreach (T item in this)
        //    {
        //        stringbuilder.AppendLine(item.ToString());
        //    }
        //    return stringbuilder.ToString();
        //}
    }
}