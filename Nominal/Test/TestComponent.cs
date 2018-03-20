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
        LineRenderer lr;

        public override void Awake()
        {
            o = new Orbit(4, 0.99, 1, 200, 0, true);
        }
        public override void Start()
        {
            gameObject.GetComponent<LineRenderer>().points = o.GetSubsets(50, true);
            Texture2D tex = gameObject.GetComponent<LineRenderer>().texture;
            lr = gameObject.AddComponent<LineRenderer>();
            lr.texture = tex;
            lr.color = Color.Red;
            lr.transformSpace = TransformSpace.World;
        }
     
        public void Draw(DrawHelper drawBuffer)
        {

        }

        public void Update()
        {
            o.UpdateOrbit(Time.deltaTimeUpdate);
            lr.points = new DVector2[] { DVector2.zero, o.position };
            transform.position = o.position;
            Camera.mainCamera.cameraSize += InputManager.mouseDelta / 100;
        }

        public override void OnDestroy()
        {

        }
    }
}
