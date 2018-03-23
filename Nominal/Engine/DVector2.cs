using Microsoft.Xna.Framework;
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
        public static DVector2 uniform
        {
            get
            {
                return new DVector2(1, 1);
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
        public double angle
        {
            get
            {
                double a = System.Math.Acos(X/magnitude);
                if(Y<0)
                {
                    a = 2 * System.Math.PI - a;
                }
                return a;
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

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
        public Vector2 ToVector2()
        {
            return new Vector2((float)X, (float)Y);
        }

        public DVector2 Rotate(double angle)
        {
            return new DVector2(System.Math.Cos(angle) * X - System.Math.Sin(angle) * Y, System.Math.Sin(angle) * X + System.Math.Cos(angle) * Y);
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
