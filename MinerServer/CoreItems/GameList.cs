using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerServer.CoreItems
{
    public interface IGameList<T> : ICollection<T>
    {
        void Trim();

        void Remove(Func<T, bool> condition);

    }

    public class GameList<T> : IGameList<T>
    {
        private ListComponent<T> firstItem;

        class ListComponent<TItem>
        {
            private readonly TItem listItem;
            public ListComponent<TItem> NextElement;
            public bool Removed { get; private set; }

            public void Remove()
            {
                Removed = true;
            }

            public TItem Item
            {
                get { return listItem; }
            }

            public ListComponent(TItem item)
            {
                listItem = item;
            }
        }

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
                : new ListComponent<T>(item) { NextElement = firstItem };
            Count++;
        }

        public void Clear()
        {
            firstItem = null;
            Count = 0;
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void Trim()
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null && iterator.Removed)
            {
                iterator = firstItem = iterator.NextElement;
                Count--;
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
                    Count--;
                }
                else
                {
                    iterator = iterator.NextElement;
                    prev = prev.NextElement;
                }
            }
        }

        public bool Remove(T item)
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (ReferenceEquals(iterator.Item, item))
                {
                    iterator.Remove();
                    Count--;
                    return true;
                }
                iterator = iterator.NextElement;
            }
            return false;
        }

        public void Remove(Func<T, bool> condition)
        {
            ListComponent<T> iterator = firstItem;
            while (iterator != null)
            {
                if (condition(iterator.Item))
                {
                    iterator.Remove();
                    Count--;
                }
                iterator = iterator.NextElement;
            }
        }

        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendLine(string.Format("Items count:{0}", Count));
            foreach (T item in this)
            {
                stringbuilder.AppendLine(item.ToString());
            }
            return stringbuilder.ToString();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
    }
}
