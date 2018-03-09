﻿using Nominal.Engine;
using Nominal.Components.Cam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Nominal.Components
{
    class SpriteRenderer : Component, Engine.IDrawable
    {
        public Texture2D texture;

        public override void Awake()
        {
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if(Camera.mainCamera)
            {
                transform.size = new DVector2(100, 100);
                Camera.mainCamera.DrawSprite(spriteBatch, texture, transform);
            }
        }

        public override void OnDestroy()
        {
            
        }
        public override void Start()
        {
            
        }
    }
}
