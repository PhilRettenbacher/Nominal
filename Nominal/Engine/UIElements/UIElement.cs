using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.UIElements
{
    abstract class UIElement : Engine.IDrawable, Engine.IUpdateable
    {
        private DVector2 _position;
        public DVector2 position
        {
            get;
            set;
        }

        private DVector2 _size;
        public DVector2 size
        {
            get;
            set;
        }

        public abstract void Draw(DrawHelper drawBuffer);

        public abstract void Update();

        
    }
}
