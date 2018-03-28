using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Components;
using Nominal.Components.Cam;
using Nominal.Components.Orbital;
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
        public Orbit o;

        public override void Start()
        {
            o = new Orbit(5, 0.8, 2, 200, 2, true);
            OrbitLines ol = gameObject.AddComponent<OrbitLines>();
            ol.SetOrbit(o);
        }
     
        public void Draw(DrawHelper drawBuffer)
        {

        }

        public void Update()
        {
            o.UpdateOrbit(Time.deltaTimeUpdate);
            transform.localPosition = o.position;
            Camera.mainCamera.cameraSize += InputManager.mouseDelta / (float)200;
            transform.rotation += Time.deltaTimeUpdate * 2;
        }
        /*
        public override void OnDestroy()
        {

        }
        */
    }
}
