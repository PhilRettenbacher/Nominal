using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.UI
{
    public abstract class UIObject : Object
    {
        override protected sealed void Destroy()
        {
            base.Destroy();// hier wird die base zerstört
        }
    }
}
