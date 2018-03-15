using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.OrbitalMechanics
{
    public static class OrbitMath
    {
        /// <summary>
        /// Converts True Anomaly to Mean Anomaly
        /// </summary>
        public static double ConvertTrueToMeanElliptic(double trueAnomaly, double eccentricity)
        {
            double E = System.Math.Acos((eccentricity + System.Math.Cos(trueAnomaly)) / (1 + eccentricity * System.Math.Cos(trueAnomaly)));
            return E - eccentricity * System.Math.Sin(E);
        }
        /// <summary>
        /// Converts Mean Anomaly to True Anomaly
        /// </summary>
        public static double ConvertMeanToTrueElliptic(double meanAnomaly, double eccentricity)
        {
            //spooky scary math stuff
            double deltaE = 0;
            double E = 0;

            //Aproximation of starting values
            double El = meanAnomaly;
            if (eccentricity < 0.7)
            {
                El = System.Math.Pow(6 * meanAnomaly, 1 / 3);
            }

            //This is just old code, but it works
            int maxCount = 1000;
            for (int i = 0; i < maxCount; i++)
            {
                E = meanAnomaly + eccentricity * System.Math.Sin(El);
                deltaE = E - El;
                if (deltaE == 0)
                    break;
                El = E;

            }
            double v = System.Math.Acos((System.Math.Cos(E) - eccentricity) / (1 - eccentricity * System.Math.Cos(E)));
            if (E > System.Math.PI)
                v = 2 * System.Math.PI - v;
            return v;
        }

    }
}
