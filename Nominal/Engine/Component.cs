using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Component
    {
        public bool enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if(value!=_enabled)
                {
                    _enabled = value;
                    if(value)
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
        bool _enabled;

        abstract public void Start();
        abstract public void OnEnable();
        abstract public void OnDisable();
        abstract public void OnDestroy();
    }
}
