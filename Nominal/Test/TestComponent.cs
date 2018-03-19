using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Components;
using Nominal.Components.Cam;
using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Test
{
    class TestComponent : Component, Engine.IDrawable, Engine.IUpdateable
    {
        DVector2 dist = new DVector2(10, 0);
        public override void Awake()
        {
            Console.WriteLine("Awake");
        }
        public override void Start()
        {
            Console.WriteLine("Start");
        }
     
        public void Draw(DrawHelper drawBuffer)
        {

        }

        public void Update()
        {
            
            LineRenderer lr = this.gameObject.GetComponent<LineRenderer>();
            if(lr)
                lr.points = new DVector2[] { new DVector2(-5, 0), dist, dist.Rotate(System.Math.PI), dist + new DVector2(10, 0), new DVector2(5, -5), dist*2+new DVector2(-2, 0), new DVector2(10, -5), new DVector2(5, 200)};
            Camera.mainCamera.cameraSize += InputManager.mouseDelta*0.01f;
            System.Console.WriteLine(dist);
            dist = dist.Rotate(System.Math.PI * Time.deltaTimeUpdate);
        }

        public override void OnDestroy()
        {
            Console.WriteLine("Destroyed");
        }
    }
}
