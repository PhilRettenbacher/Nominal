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
        private bool _enabled;

        public GameObject gameObject
        {
            get
            {
                return _gameObject;
            }
            set
            {
                if(!_gameObject)
                {
                    _gameObject = value;
                    _transform = _gameObject.transform;
                }
            }
        }
        private GameObject _gameObject;

        public Transform transform
        {
            get
            {
                return _transform;
            }
        }
        private Transform _transform;

        abstract public void Start();
        abstract public void OnEnable();
        abstract public void OnDisable();
        abstract public void OnDestroy();
    }
}
