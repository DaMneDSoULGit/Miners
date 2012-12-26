using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerServer.CoreItems
{
    public static class LinqHelper
    {

        public static void Invoke<T>(this IEnumerable<T> enumer, Action<T> action)
        {
            foreach (var item in enumer)
            {
                action(item);
            }
        }

    }
}
