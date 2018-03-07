using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Container : Object
    {
        public Transform transform
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _transform;
            }
            set
            {
                if (isDestroyed)
                    return;
                else if (!_transform)
                    _transform = value;
            }
        }
        private Transform _transform;

        public GameObject gameObject
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _gameObject;
            }
            set
            {
                if (isDestroyed)
                    return;
                else if (!_gameObject)
                    _gameObject = value;
            }
        }
        private GameObject _gameObject;

        override protected void Destroy()
        {
            base.Destroy();
            _transform = null;
            _gameObject = null;
        }
    }
}
