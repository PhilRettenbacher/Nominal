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
    public class LineRenderer : Component, Engine.IDrawable, IUniqueComponent
    {
        public Transform target;
        public Texture2D texture;
        public Color color = Color.White;
        public DVector2[] points
        {
            set
            {
                _points = value;
                RecalculateLines();
            }
        }
        private DVector2[] _points;
        public double width = 2;

        private RenderLine[] renderLines;

        public override void Awake()
        {
            texture = Assets.GetTexture("placeholder001");
        }
        /*
        public override void Start()
        {

        }
        */
        public void Draw(DrawHelper drawBuffer)
        {
            for(int i = 0; i<renderLines.Length; i++)
            {
                drawBuffer.DrawLine(texture, target, renderLines[i].pos, width, renderLines[i].scale, renderLines[i].rotation, DrawSpace.World, color);
            }
        }
        /*
        public override void OnDestroy()
        {
            
        }
        */
        public void SetPointAt(DVector2 value, int index)
        {
            _points[index] = value;
            RecalculateLines();
        }
        private void RecalculateLines()
        {
            if (_points.Length == 0)
                return;
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
