using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;

namespace MinerServer.CoreItems
{
    public class WeakGameList<T> : IGameList<T> where T : class
    {
        readonly GameList<WeakGameObject<T>> container = new GameList<WeakGameObject<T>>();
        public IEnumerator<T> GetEnumerator()
        {
            return (container.Where(weakGameObject => !weakGameObject.Deleted).Select(
                weakGameObject => weakGameObject.GetItem)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            container.Add(new WeakGameObject<T>(item));
        }

        public void Clear()
        {
            container.Invoke(x => x.SetFree());
            container.Clear();
        }

        public void Trim()
        {
            container.Remove(x => x.Deleted);
            container.Trim();
        }

        public void Remove(Func<T, bool> condition)
        {
            foreach (WeakGameObject<T> weakGameObject in container)
            {
                if (!weakGameObject.Deleted && condition(weakGameObject.GetItem))
                {
                    weakGameObject.SetFree();
                }
            }
        }

        public bool Contains(T item)
        {
            throw new InvalidOperationException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            foreach (var weakGameObject in container.Where(weakGameObject => ReferenceEquals(weakGameObject, item)))
            {
                weakGameObject.SetFree();
                return true;
            }
            throw new InstanceNotFoundException();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Items count:{0}", Count));
            foreach (T item in this)
            {
                builder.AppendLine(item.ToString());
            }
            return builder.ToString();
        }

        public int Count
        {
            get { return container.Count(x => !x.Deleted); }
        }

        public bool IsReadOnly { get; private set; }

    }
}
