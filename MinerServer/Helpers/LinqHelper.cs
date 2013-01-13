#region

using System;
using System.Collections.Generic;

#endregion

namespace MinerServer.Helpers
{
    public static class LinqHelper
    {
        public static void Invoke<T>(this IEnumerable<T> enumer, Action<T> action)
        {
            foreach (T item in enumer)
            {
                action(item);
            }
        }
    }
}