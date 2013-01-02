using System;
using System.Collections;
using System.Collections.Generic;

namespace MinerServer.CoreItems
{
    public abstract class Child<TParent> where TParent : HierarhyContainer<Child<TParent>>
    {
        protected Child(TParent item)
        {
            Parent = item;
        }
        public TParent Parent { get; private set; }
    }

    public abstract class HierarhyContainer<TChild> : IObjectContainer<TChild>
    {
        public IObjectContainer<TChild> ChildList = new DynamicList<TChild>();
        public void Add(TChild item)
        {
            ChildList.Add(item);
        }

        public bool Contains(TChild item)
        {
            return ChildList.Contains(item);
        }

        public void Trim()
        {
            ChildList.Trim();
        }

        public void Remove(Func<TChild, bool> condition)
        {
            ChildList.Remove(condition);
        }

        public void Remove(TChild item)
        {
            ChildList.Remove(item);
        }

        public void Clear()
        {
            ChildList.Clear();
        }

        public IEnumerator<TChild> GetEnumerator()
        {
            return ChildList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ChildList.GetEnumerator();
        }
    }

}
