using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nominal.Engine;

namespace Nominal.Engine.UI
{
    class UIRect : Object
    {
        public UIRect parent;
        private UIRect _parent;
        override protected void Destroy()
        {
            base.Destroy(); //hier wird die base zerstört
        }
    }
}
