using System;
using MinerServer.CoreItems;

namespace MinerServer.MapObjects
{
    public struct Point
    {
        public bool Equals(Point other)
        {
            return MathUtils.DoubleEquals(X, other.X) && MathUtils.DoubleEquals(Y, other.Y);
        }

        public double X;
        public double Y;

        public static Point EmptyPoint = new Point(-1, -1);

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsEmpty
        {
            get { return Equals(EmptyPoint); }
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
