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
    //Edit: variables are still named drawBuffer... still misleading
    //Edit: It's called DrawHelper now, but it's still called drawbuffer almost everywhere ¯\_(ツ)_/¯
    public class DrawHelper
    {

        SpriteBatch spriteBatch;
        static Vector2 _screenSize;

        Camera mainCamera;

        public static Vector2 screenSize
        {
            get
            {
                return _screenSize;
            }
        }

        public DrawHelper(SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;
            _screenSize = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
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
            pos = new Vector2(pos.X * _screenSize.X, pos.Y * _screenSize.X) + _screenSize / 2;

            if (drawSpace == DrawSpace.World)
            {
                size *= _screenSize.X / mainCamera.cameraSize;
            }
            Rectangle destination = new Rectangle((int)pos.X, (int)_screenSize.Y-(int)pos.Y, (int)size.X, (int)size.Y);

            spriteBatch.Draw(texture, destination, null, color, -(float)rotation, pivot, SpriteEffects.None, 0.0f);
        }
        public void DrawLine(Texture2D texture, Transform origin, DVector2 position, double width, double length, double rotation, DrawSpace drawSpace, Color color)
        {
            if (!mainCamera)
            {
                System.Console.WriteLine("No Camera");
                return;
            }
            Vector2 pos = ((Transform.GetRelativePos(origin, mainCamera.transform) + position) / mainCamera.cameraSize).ToVector2();
            pos = new Vector2(pos.X * _screenSize.X, pos.Y * _screenSize.X) + _screenSize / 2;

            if (drawSpace == DrawSpace.World)
            {
                length *= _screenSize.X / mainCamera.cameraSize;
            }
            Rectangle destination = new Rectangle((int)pos.X, (int)_screenSize.Y-(int)pos.Y, (int)Math.Ceiling(length), (int)Math.Ceiling(width));

            spriteBatch.Draw(texture, destination, null, color, -(float)rotation, new Vector2(0, ((float)texture.Height) / 2f), SpriteEffects.None, 0.0f);
        }
        public void DrawUI(Texture2D texture, Rectangle viewRect, Color color)
        {
            spriteBatch.Draw(texture, viewRect, color);
        }
        /*private Rectangle ReferenceCOToReal(Rectangle pivotRect, Rectangle offsetRect)
        {
            //TODO
            return new Rectangle((int)(pivotRect.X * (_screenSize.X / Nominal.Engine.UI.UIObject.REFERENCE_SCREEN_WIDTH)), (int)(pivotRect.Y * (_screenSize.Y / Nominal.Engine.UI.UIObject.REFERENCE_SCREEN_HEIGHT)), (int)(pivotRect.Width * (_screenSize.X / Nominal.Engine.UI.UIObject.REFERENCE_SCREEN_WIDTH)), (int)(pivotRect.Height * (_screenSize.Y / Nominal.Engine.UI.UIObject.REFERENCE_SCREEN_HEIGHT)));
        }*/
    }
}
