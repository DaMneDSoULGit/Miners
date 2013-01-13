#region

using System;

#endregion

namespace MinerServer.CoreItems
{
    public class WeakObject<T> where T : class
    {
        private readonly WeakReference reference;

        public WeakObject(T item)
        {
            reference = new WeakReference(item);
        }

        public T Value
        {
            get { return (T) reference.Target; }
        }
    }
}