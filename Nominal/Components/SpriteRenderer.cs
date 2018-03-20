using Nominal.Engine;
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
        public Color color = Color.Green;
        public float unitsPerPixel = 1f;
        public bool normalizeSize = false;

        public override void Awake()
        {
            
        }
        
        public void Draw(DrawHelper drawBuffer)
        {
            DVector2 size = DVector2.zero;
            if (normalizeSize)
            {
                Vector2 norm = new Vector2(texture.Width, texture.Height);
                if (norm.X > norm.Y)
                {
                    norm.Y /= norm.X;
                    norm.X = 1;
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

            drawBuffer.DrawSprite(texture, transform, DVector2.zero, size, DrawSpace.World, transform.rotation, new Vector2(texture.Width/2.0f, texture.Height/2.0f), color);
        }

        public override void OnDestroy()
        {
            
        }
        public override void Start()
        {
            
        }
    }
}
