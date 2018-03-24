using Nominal.Engine;
using Nominal.OrbitalMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Components.Orbital
{
    class OrbitLines : Component, IUniqueComponent
    {
        LineRenderer lr;
        Orbit orbit;

        public int subsets
        {
            get
            {
                return _subsets;
            }
            set
            {
                _subsets = value;
                Recalculate();
            }
        }
        private int _subsets = 100;

        public override void Awake()
        {
            lr = gameObject.GetComponent<LineRenderer>();
            if (!lr)
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }
        }
        /*
        public override void OnDestroy()
        {
            
        }

        public override void Start()
        {

        }
        */
        public void SetOrbit(Orbit _orbit)
        {
            orbit = _orbit;
            Recalculate();
        }
        public void Recalculate()
        {
            if (orbit == null)
                return;
            lr.target = transform.parent;
            lr.points = orbit.GetSubsets(_subsets);
        }
    }
}
