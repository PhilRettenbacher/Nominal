using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Component : Container
    {
        //Made virtual not abstract because sometimes no need to override
        virtual public void Awake() { }
        virtual public void Start() { }
        virtual public void OnDestroy() { }


        override protected sealed void Destroy()
        {
            OnDestroy();
            GameObject currGo = gameObject;
            base.Destroy();
            currGo.RemoveComponent(this);
        }
    }
}
