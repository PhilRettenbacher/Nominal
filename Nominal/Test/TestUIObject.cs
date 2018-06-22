using Microsoft.Xna.Framework;
using Nominal.Engine;
using Nominal.Engine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Test
{
    public class TestUIObject : UIObject, Nominal.Engine.IDrawable
    {
        public Color color;
        public void Draw(DrawHelper drawBuffer)
        {
            //TODO: Rewrite GetViewRect to Support different Resolutions (pivot + offsetRect)
            drawBuffer.DrawUI(Assets.GetTexture("placeholder001"), GetViewRect(), color);
            Console.WriteLine("DrawUI");
            Console.WriteLine(GetViewRect().X + " " + GetViewRect().Y + " " + GetViewRect().Width + " " + GetViewRect().Height);
        }
    }
}
