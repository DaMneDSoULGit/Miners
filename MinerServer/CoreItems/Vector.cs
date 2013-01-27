using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinerServer.Helpers;

namespace MinerServer.CoreItems
{
    public struct Vector
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector && Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static readonly Vector ZeroVector = FromXY(0, 0);

        public readonly double X;
        public readonly double Y;

        public bool Equals(Vector obj)
        {
            return MathHelper.DoubleEquals(obj.X, X) && MathHelper.DoubleEquals(obj.Y, Y);
        }

        public static bool operator ==(Vector vector, Vector vector2)
        {
            return vector.Equals(vector2);
        }

        public static bool operator !=(Vector vector, Vector vector2)
        {
            return !(vector == vector2);
        }

        private Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("Vector X: {0:0.###} Y: {1:0.###}", X, Y);
        }

        public static Vector FromXY(double x, double y)
        {
            return new Vector(x, y);
        }

        public static Vector FromAngle(double angle)
        {
            angle = (angle + 90) / 180 * Math.PI;
            return new Vector(Math.Cos(angle), Math.Sin(angle));
        }
    }
}
