#region

using System;
using System.Collections.Generic;

#endregion

namespace MinerServer.CoreItems
{
    public interface IObjectContainer<T> : IEnumerable<T>
    {
        void Add(T item);
        bool Contains(T item);
        void Trim();
        void Remove(Func<T, bool> condition);
        void Remove(T item);
        void Clear();
    }

    public class Container
    {
        public static IObjectContainer<T> CreateContainer<T>()
        {
            return new DynamicList<T>();
        }
    }

}