using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Components.Cam
{
    class Camera : Component
    {
        public static Camera mainCamera;
        public static GraphicsDeviceManager graphics;

        /// <summary>
        /// In meters.
        /// </summary>
        public float cameraSize = 1; 

        public override void Awake()
        {
            if (!mainCamera)
                mainCamera = this;
        }
        public override void OnDestroy()
        {
            
        }
        public override void Start()
        {
            
        }
        private DVector2 Translate(Transform curr)
        {
            DVector2 pos = Transform.GetRelativePos(curr, transform);

            return pos;
        }
        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, DVector2 position, DVector2 size, double rotation, DVector2 origin)
        {
            position /= cameraSize;
            Vector2 screenSize = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            Vector2 pos = new Vector2((float)position.X * screenSize.X, (float)position.Y * screenSize.X) + screenSize / 2;
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destination, null, Color.White, (float)rotation, origin.ToVector2(), SpriteEffects.None, 0.0f);
        }
        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture, Transform trans)
        {
            DVector2 pos = Translate(trans);
            DrawSprite(spriteBatch, texture, pos, trans.size, trans.rotation, new DVector2(texture.Width/2, texture.Height/2));

        }
    }
}
