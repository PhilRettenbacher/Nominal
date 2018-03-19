using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Components;
using Nominal.Components.Cam;
using Nominal.Engine;
using Nominal.OrbitalMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Test
{
    class TestComponent : Component, Engine.IDrawable, Engine.IUpdateable
    {
        Orbit o;
        public override void Awake()
        {
            o = new Orbit(10, 0.1, 0, 100, 0);
        }
        public override void Start()
        {

        }
     
        public void Draw(DrawHelper drawBuffer)
        {

        }

        public void Update()
        {
            o.UpdateOrbit(Time.deltaTimeUpdate);
        }

        public override void OnDestroy()
        {

        }
    }
}
