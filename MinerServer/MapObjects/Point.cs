#region

using System;
using MinerServer.Helpers;

#endregion

namespace MinerServer.MapObjects
{
    public struct Point
    {
        public static Point EmptyPoint = new Point(-1, -1);
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsEmpty
        {
            get { return Equals(EmptyPoint); }
        }

        public bool Equals(Point other)
        {
            return MathHelper.DoubleEquals(X, other.X) && MathHelper.DoubleEquals(Y, other.Y);
        }

        public static double Range(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(point1.X - point2.X), 2) + Math.Pow(Math.Abs(point2.Y - point1.Y), 2));
        }

        public double RangeTo(Point point)
        {
            return Range(this, point);
        }

        public static bool IsInRange(Point point1, Point point2, double range)
        {
            if (Math.Abs(point1.X - point2.X) >= range) return true;
            if (Math.Abs(point1.Y - point2.Y) >= range) return true;
            return Range(point1, point2) >= range;
        }
    }
}