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
            Console.WriteLine("Awake");
        }
        public override void Start()
        {
            Console.WriteLine("Start");
        }
     
        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update()
        {

        }

        public override void OnDestroy()
        {
            Console.WriteLine("Destroyed");
        }
    }
}
