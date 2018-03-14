using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Nominal.Components
{
    public class LineRenderer : Component, Engine.IDrawable
    {
        public TransformSpace transformSpace = TransformSpace.Local;
        public Texture2D texture;
        public Color color = Color.White;
        public DVector2[] points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
                RecalculateLines();
            }
        }
        private DVector2[] _points;
        public double width = 1;

        private RenderLine[] renderLines;

        public override void Awake()
        {
            
        }
        public override void Start()
        {

        }

        public void Draw(DrawBuffer drawBuffer)
        {
            System.Console.WriteLine(renderLines.Length);
            for(int i = 0; i<renderLines.Length; i++)
            {
                drawBuffer.DrawSprite(texture, transformSpace == TransformSpace.World ? null : transform, renderLines[i].pos, new DVector2(renderLines[i].scale, width), DrawSpace.World, renderLines[i].rotation, new Vector2(0, ((float)texture.Height)/2f), color);
            }
        }

        public override void OnDestroy()
        {
            
        }

        private void RecalculateLines()
        {
            renderLines = new RenderLine[_points.Length-1];
            for(int i = 0; i<renderLines.Length; i++)
            {
                DVector2 diff = _points[i + 1] - _points[i];
                renderLines[i] = new RenderLine() { pos = _points[i], rotation = diff.angle, scale = diff.magnitude };
            }
        }
    }
    class RenderLine
    {
        public DVector2 pos;
        public double rotation;
        public double scale;
        public RenderLine()
        {

        }
    }
}
