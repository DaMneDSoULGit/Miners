using MinerServer.Helpers;

namespace MinerServer.CoreItems
{
    public struct Point
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        public readonly double X;
        public readonly double Y;

        private Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point FromXY(double x, double y)
        {
            return new Point(x, y);
        }

        public bool IsEmpty()
        {
            return Equals(Empty());
        }

        public static Point Empty()
        {
            return new Point(0, 0);
        }

        public bool Equals(Point obj)
        {
            return MathHelper.DoubleEquals(X, obj.X) && MathHelper.DoubleEquals(Y, obj.Y);
        }

        public static bool operator ==(Point point, Point p2)
        {
            return point.Equals(p2);
        }

        public static bool operator !=(Point point, Point p2)
        {
            return !(point == p2);
        }

        public static Vector operator -(Point pos1, Point pos2)
        {
            return Vector.FromXY(pos1.X - pos2.X, pos1.Y - pos2.Y);
        }

        public static Point operator -(Point pos1, Vector vecr)
        {
            return FromXY(pos1.X - vecr.X, pos1.Y - vecr.Y);
        }

        public static Point operator +(Point point, Vector vect)
        {
            return FromXY(point.X + vect.X, point.Y + vect.Y);
        }

        public override string ToString()
        {
            return string.Format("Point X: {0} Y: {1}", X, Y);
        }
    }
}