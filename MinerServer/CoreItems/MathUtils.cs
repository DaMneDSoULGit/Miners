using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerServer.CoreItems
{
    class MathUtils
    {
        private const double Epsilon = 0.0001;

        public static bool DoubleEquals(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < Epsilon;
        }
    }
}
