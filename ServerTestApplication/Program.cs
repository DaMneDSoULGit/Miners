using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.CoreItems;

namespace ServerTestApplication
{
    class Program
    {
        static void Main()
        {
            var list = new WeakGameList<object> { new object(), new object(), new object() };
            Console.WriteLine(list);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            list.Trim();
            
            Console.WriteLine(list);
            Console.ReadLine();
        }
    }
}
