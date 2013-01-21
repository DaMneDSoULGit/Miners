using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinerServer.CoreItems
{
    public struct Vector
    {
        public readonly double X;
        public readonly double Y;


        public double Lenght
        {
            get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)); }
        }

        private Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("Vector X: {0} Y: {1}", X, Y);
        }

        public static Vector FromXY(double x, double y)
        {
            return new Vector(x, y);
        }
    }
}
