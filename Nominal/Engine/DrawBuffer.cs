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
    public class DrawBuffer
    {
        List<BufferValue> buffer = new List<BufferValue>();

        SpriteBatch spriteBatch;

        public DrawBuffer(SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;    
        }
        public void DrawSprite(Texture2D texture, Transform origin, DVector2 offset, DVector2 size, DrawSpace drawSpace, double rotation, Vector2 pivot, Color color)
        {
            buffer.Add(new BufferValue(texture, origin, offset, size, drawSpace, rotation, pivot, color));
        }
        public void Finish()
        {
            if (!Camera.mainCamera)
            {
                System.Console.WriteLine("No Main Camera defined!");
                return;
            }
            Vector2 screenSize = new Vector2(spriteBatch.GraphicsDevice.Viewport.Width, spriteBatch.GraphicsDevice.Viewport.Height);
            Camera main = Camera.mainCamera;
            foreach(BufferValue b in buffer)
            {
                Vector2 pos = ((Transform.GetRelativePos(b.origin, main.transform)+b.offset)/main.cameraSize).ToVector2();
                pos = new Vector2(pos.X * screenSize.X,pos.Y * screenSize.X) + screenSize / 2;
                Vector2 pivot = b.pivot;
                Vector2 size = b.size.ToVector2();
                if(b.drawSpace==DrawSpace.World)
                {
                    size *= screenSize.X / main.cameraSize;
                }
                Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y);

                spriteBatch.Draw(b.texture, destination, null, b.color, (float)b.rotation, pivot, SpriteEffects.None, 0.0f);
            }
        }
    }
    class BufferValue
    {
        public Texture2D texture;
        public Transform origin;
        public DVector2 offset;
        public DVector2 size;
        public DrawSpace drawSpace;
        public double rotation;
        public Vector2 pivot;
        public Color color;

        public BufferValue(Texture2D _texture, Transform _origin, DVector2 _offset, DVector2 _size, DrawSpace _drawSpace, double _rotation, Vector2 _pivot, Color _color)
        {
            texture = _texture;
            origin = _origin;
            offset = _offset;
            size = _size;
            drawSpace = _drawSpace;
            rotation = _rotation;
            pivot = _pivot;
            color = _color;
        }
    }
}
