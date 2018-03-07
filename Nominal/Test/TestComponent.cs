using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public override void Awake()
        {

        }
        public override void Start()
        {

        }


        public override void OnDestroy()
        {
            System.Console.WriteLine("Destroyed");
        }
        public override void OnDisable()
        {
            System.Console.WriteLine("Disabled");
        }
        public override void OnEnable()
        {
            System.Console.WriteLine("Enabled");
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            System.Console.WriteLine("Draw: " + Time.deltaTimeDraw + " : " + Time.time);
        }

        public void Update()
        {
            System.Console.WriteLine("Update: " + Time.deltaTimeUpdate + " : " + Time.time);
        }
    }
}
