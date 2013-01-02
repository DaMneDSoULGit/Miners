using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using MinerServer.CoreGameObjects;

namespace MinerServer.CoreItems
{
    public class WeakObjectContainer<T> : IObjectContainer<T> where T : class
    {
        readonly DynamicList<WeakObject<T>> container = new DynamicList<WeakObject<T>>();
        public IEnumerator<T> GetEnumerator()
        {
            return (container.Select(weakGameObject => weakGameObject.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            container.Add(new WeakObject<T>(item));
        }

        public void Clear()
        {
            container.Clear();
        }

        public void Trim()
        {
            container.Trim();
        }

        public void Remove(Func<T, bool> condition)
        { 
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        
        public void Remove(T item)
        {
            throw new NotImplementedException();
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
            get { return container.Count(); }
        }

        public bool IsReadOnly { get; private set; }
    }

    public class WeakGameObjectList : WeakObjectContainer<GameObject>
    { }
}
