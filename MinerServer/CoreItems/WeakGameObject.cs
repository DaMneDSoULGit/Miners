using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerServer.CoreItems
{
    public class WeakGameObject<T> where T : class
    {
        public bool Deleted
        {
            get { return deleted || reference.Target == null; }
        }

        public void SetFree()
        {
            deleted = true;
        }

        private readonly WeakReference reference;
        private bool deleted;

        public WeakGameObject(T item)
        {
            reference = new WeakReference(item);
        }

        public T GetItem
        {
            get { return !deleted ? (T)reference.Target : null; }
        }

    }
}
