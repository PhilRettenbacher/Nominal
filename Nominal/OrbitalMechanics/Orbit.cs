using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.OrbitalMechanics
{
    public class Orbit
    {
        public double trueAnomaly
        {
            get
            {
                return _trueAnomaly;
            }
        }
        private double _trueAnomaly;

        public double semiMajorAxis
        {
            get
            {
                return _semiMajorAxis;
            }
        }
        private double _semiMajorAxis;

        public double eccentricity
        {
            get
            {
                return _eccentricity;
            }
        }
        private double _eccentricity;

        public double argumentOfPeriapsis
        {
            get
            {
                return _argumentOfPeriapsis;
            }
        }
        private double _argumentOfPeriapsis;

        private double meanAnomaly;
        private double gravParameter;

        public Orbit(double semiMajorAxis, double eccentricity, double argumentOfPeriapsis, double gravParameter)
        {
            _semiMajorAxis = semiMajorAxis;
            _eccentricity = eccentricity;
            _argumentOfPeriapsis = argumentOfPeriapsis;
            this.gravParameter = gravParameter;
        }

        public double periapsis
        {
            get
            {
                return _semiMajorAxis * (1 - _eccentricity);
            }
        }
        public double apoapsis
        {
            get
            {
                return _semiMajorAxis * (1 + _eccentricity);
            }
        }
        public double radius
        {
            get
            {
                return _semiMajorAxis * (1 - System.Math.Pow(_eccentricity, 2)) / (1 + _eccentricity * System.Math.Cos(_trueAnomaly));
            }
        }
        public DVector2 positionVector
        {
            get
            {
                //TODO
                return DVector2.zero;
            }
        }
        public double velocity
        {
            get
            {
                //TODO
                return 0;
            }
        }
        public DVector2 velocityVector
        {
            get
            {
                //TODO
                return DVector2.zero;
            }
        }
    }
}
