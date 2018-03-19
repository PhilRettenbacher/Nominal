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
        private double meanMotion;

        private double fullRotation
        {
            get
            {
                return _trueAnomaly + _argumentOfPeriapsis;
            }
        }

        public double periapsis
        {
            get
            {
                return _periapsis;
            }
        }
        private double _periapsis;
        public double apoapsis
        {
            get
            {
                return _apoapsis;
            }
        }
        private double _apoapsis;

        public double radius
        {
            get
            {
                return _radius;
            }
        }
        private double _radius;
        public DVector2 position
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
                return _velocity;
            }
        }
        private double _velocity;
        public DVector2 velocityVector
        {
            get
            {
                //TODO
                return DVector2.zero;
            }
        }
        private double flightPathAngle;

        public Orbit(double semiMajorAxis, double eccentricity, double argumentOfPeriapsis, double gravParameter, double meanAnomaly)
        {
            _semiMajorAxis = semiMajorAxis;
            _eccentricity = eccentricity;
            _argumentOfPeriapsis = argumentOfPeriapsis;
            this.gravParameter = gravParameter;

            this.meanAnomaly = meanAnomaly;
            _trueAnomaly = OrbitMath.ConvertMeanToTrueElliptic(this.meanAnomaly, _eccentricity);

            meanMotion = System.Math.Sqrt(gravParameter / System.Math.Pow(_semiMajorAxis, 3));

            _periapsis = _semiMajorAxis * (1 - _eccentricity);
            _apoapsis = _semiMajorAxis * (1 + _eccentricity);
            _radius = _semiMajorAxis * (1 - Math.Pow(_eccentricity, 2)) / (1 + _eccentricity * System.Math.Cos(_trueAnomaly));

            flightPathAngle = Math.Atan(_eccentricity * Math.Sin(_trueAnomaly) / (1 + _eccentricity * Math.Cos(_trueAnomaly)));
            _velocity = (Math.Sqrt(gravParameter * (2 / _radius - 1 / _semiMajorAxis)));
        }
    }
}
