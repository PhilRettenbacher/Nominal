using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.DMath
{
    public static class DMath
    {
        public static double aCosh(double x)
        {
            return System.Math.Log(x + System.Math.Sqrt(x * x - 1));
        }
    }
}
