using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Object
    {
        private bool destroyed;

        public bool isDestroyed
        {
            get
            {
                return destroyed;
            }
        }

        protected virtual void Destroy()
        {
            destroyed = true;
        }
        public static void Destroy(Object toDestroy)
        {
            toDestroy.Destroy();
        }
        public static implicit operator bool(Object gameObject)
        {
            return gameObject == null ? false : !gameObject.destroyed;
        }
    }
}
