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
    class SpriteRenderer : Component, Engine.IDrawable, IUniqueComponent
    {
        public Texture2D texture;
        public Color color = Color.Green;
        public float unitsPerPixel = 1f;
        public bool normalizeSize = false;

        public override void Awake()
        {
            if(texture == null)
                texture = Assets.GetTexture("placeholder001");
        }
        
        public void Draw(DrawHelper drawHelper)
        {
            DVector2 size = DVector2.zero;
            if (normalizeSize)
            {
                Vector2 norm = new Vector2(texture.Width, texture.Height);
                if (norm.X > norm.Y)//wenn die norm x größerals die norm y 
                {
                    norm.Y /= norm.X;   //ist
                    norm.X = 1;                     //dann gehen wir hier rein
                }
                else
                {
                    norm.X /= norm.Y;
                    norm.Y = 1;
                }
                size = new DVector2(transform.size.X * norm.X, transform.size.Y * norm.Y)*unitsPerPixel;
            }
            else
            {
                size = new DVector2(transform.size.X * texture.Width * unitsPerPixel, transform.size.Y * texture.Height * unitsPerPixel);
            }

            drawHelper.DrawSprite(texture, transform, DVector2.zero, size, DrawSpace.World, transform.rotation, new Vector2(texture.Width/2.0f, texture.Height/2.0f), color); //okö
        }
        /*
        public override void OnDestroy()
        {
            
        }
        public override void Start()
        {
            
        }
        */
    }
}
