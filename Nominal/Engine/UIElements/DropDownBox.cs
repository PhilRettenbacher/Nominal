using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.UIElements
{
    class DropDownBox : UIElement
    {

        private bool _isDropped;

        public bool isDropped
        {
            get;
            set;
        }

        private List<UIElement> content;

        public DropDownBox()
        {
            content = new List<UIElement>();
        }

        public void addItem(UIElement element)
        {
            content.Add(element);
        }
        
        public override void Draw(DrawHelper drawBuffer)
        {
            
        }

        public override void Update()
        {
            if(InputManager.mouseClicked)
            {
                DVector2 mousepos = InputManager.mousePosition;
                
                if (mousepos.X > position.X && mousepos.X < position.X + size.X && mousepos.Y > position.Y && mousepos.Y < position.Y + size.Y)
                {
                    if (isDropped)
                    {
                        //For later use...
                        int selectedItemIndex = (int)Math.Floor(((double)mousepos.Y) / ((double)size.Y)) - 1;
                    }
                    else
                    {
                        isDropped = true;
                    }
                }
                else
                {
                    isDropped = false;
                }
                
            }
        }

    }
}
