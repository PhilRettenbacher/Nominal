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
                return (new DVector2(_radius, 0)).Rotate(fullRotation);
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
            _radius = OrbitMath.CalculateRadius(_semiMajorAxis, _eccentricity, _trueAnomaly);

            flightPathAngle = OrbitMath.CalculateFlightpathAngle(_eccentricity, _trueAnomaly);
            _velocity = OrbitMath.CalculateVelocity(this.gravParameter, _radius, _semiMajorAxis);
        }
        public void UpdateOrbit(double deltaTime)
        {
            meanAnomaly += meanMotion * deltaTime;
            _trueAnomaly = OrbitMath.ConvertMeanToTrueElliptic(meanAnomaly, _eccentricity);
            _radius = OrbitMath.CalculateRadius(_semiMajorAxis, _eccentricity, _trueAnomaly);

            flightPathAngle = OrbitMath.CalculateFlightpathAngle(_eccentricity, _trueAnomaly);
            _velocity = OrbitMath.CalculateVelocity(this.gravParameter, _radius, _semiMajorAxis);
        }
    }
}
