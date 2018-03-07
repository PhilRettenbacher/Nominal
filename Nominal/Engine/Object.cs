using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Object : IDestroyable
    {
        public bool enabled
        {
            get
            {
                if (destroyed)
                    return false;
                return _enabled;
            }
            set
            {
                if (destroyed)
                    return;
                if (value != _enabled)
                {
                    _enabled = value;
                    if (value)
                    {
                        OnEnable();
                    }
                    else
                    {
                        OnDisable();
                    }
                }
            }
        }
        private bool _enabled = true;
        protected bool destroyed;

        abstract public void OnEnable();
        abstract public void OnDisable();

        public virtual void Destroy()
        {
            destroyed = true;
        }
    }
}
