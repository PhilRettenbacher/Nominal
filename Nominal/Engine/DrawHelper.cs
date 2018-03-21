using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Components.Cam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public enum DrawSpace
    {
        World, //size value in meters
        Camera //size value in pixels
    }
    //Name is slightly misleading, it doesn't actually buffer anything, it's more like a .... draw-helper(?) EDIT: Now it is not misleading anymore, yay
    public class DrawHelper
    {

        SpriteBatch spriteBatch;
        Vector2 screenSize;

        Camera mainCamera;

        public DrawHelper(SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;
            screenSize = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            if (Camera.mainCamera)
                mainCamera = Camera.mainCamera;

        }
        public void DrawSprite(Texture2D texture, Transform origin, DVector2 offset, DVector2 size, DrawSpace drawSpace, double rotation, Vector2 pivot, Color color)
        {
            if (!mainCamera)
            {
                System.Console.WriteLine("No Camera");
                return;
            }
            Vector2 pos = ((Transform.GetRelativePos(origin, mainCamera.transform) + offset) / mainCamera.cameraSize).ToVector2();
            pos = new Vector2(pos.X * screenSize.X, pos.Y * screenSize.X) + screenSize / 2;


            if (drawSpace == DrawSpace.World)
            {
                size *= screenSize.X / mainCamera.cameraSize;
            }
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);

            spriteBatch.Draw(texture, destination, null, color, (float)rotation, pivot, SpriteEffects.None, 0.0f);
        }
        public void DrawLine(Texture2D texture, Transform origin, DVector2 position, double width, double length, double rotation, DrawSpace drawSpace, Color color)
        {
            if (!mainCamera)
            {
                System.Console.WriteLine("No Camera");
                return;
            }
            Vector2 pos = ((Transform.GetRelativePos(origin, mainCamera.transform) + position) / mainCamera.cameraSize).ToVector2();
            pos = new Vector2(pos.X * screenSize.X, pos.Y * screenSize.X) + screenSize / 2;


            if (drawSpace == DrawSpace.World)
            {
                length *= screenSize.X / mainCamera.cameraSize;
            }
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, (int)Math.Ceiling(length), (int)Math.Ceiling(width));

            spriteBatch.Draw(texture, destination, null, color, (float)rotation, new Vector2(0, ((float)texture.Height) / 2f), SpriteEffects.None, 0.0f);
        }
    }
}
