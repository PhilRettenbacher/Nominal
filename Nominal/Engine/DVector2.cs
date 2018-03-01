using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public class DVector2
    {
        public static DVector2 right
        {
            get
            {
                return new DVector2(1, 0);
            }
        }
        public static DVector2 up
        {
            get
            {
                return new DVector2(0, 1);
            }
        }
        public static DVector2 zero
        {
            get
            {
                return new DVector2(0, 0);
            }
        }

        public double X;
        public double Y;
        public double magnitude
        {
            get
            {
                return System.Math.Sqrt(X * X + Y * Y);
            }
        }
        public DVector2 normalized
        {
            get
            {
                return this * (1 / magnitude);
            }
        }

        public DVector2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static double Distance(DVector2 a, DVector2 b)
        {
            return (a - b).magnitude;
        }
        public static double Angle(DVector2 a, DVector2 b)
        {
            return System.Math.Acos(Dot(a, b) / (a.magnitude * b.magnitude));
        }
        public static double Dot(DVector2 a, DVector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public static double Cross(DVector2 a, DVector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static DVector2 operator +(DVector2 a, DVector2 b)
        {
            return new DVector2(a.X + b.X, a.Y + b.Y);
        }
        public static DVector2 operator -(DVector2 a, DVector2 b)
        {
            return new DVector2(a.X - b.X, a.Y - b.Y);
        }
        public static DVector2 operator *(DVector2 a, double b)
        {
            return new DVector2(a.X*b, a.Y*b);
        }
        public static DVector2 operator /(DVector2 a, double b)
        {
            return new DVector2(a.X / b, a.Y / b);
        }

        public override string ToString()
        {
            return "X: " + X + ", Y: " + Y;
        }
    }
}
