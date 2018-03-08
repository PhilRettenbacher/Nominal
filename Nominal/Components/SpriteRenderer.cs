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

        public override void Awake()
        {
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if(Camera.mainCamera)
            {
                //TODO: CLEANUP pls: size is not calculated correctly, make it shorter
                CameraRect rect = Camera.mainCamera.Translate(transform);
                spriteBatch.Draw(texture, new Vector2((float)rect.position.X*spriteBatch.GraphicsDevice.Viewport.Width, (float)rect.position.Y*spriteBatch.GraphicsDevice.Viewport.Width)+new Vector2(spriteBatch.GraphicsDevice.Viewport.Width/2, spriteBatch.GraphicsDevice.Viewport.Height/2), null, Color.White, (float)rect.rotation, new Vector2(texture.Width/2, texture.Height/2), (float)rect.size, SpriteEffects.None, 0);
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
