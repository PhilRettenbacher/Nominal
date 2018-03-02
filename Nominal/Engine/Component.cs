using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Component : IDestroyable
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
                if (value!=_enabled)
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

        private bool destroyed;

        public GameObject gameObject
        {
            get
            {
                if (destroyed)
                    return null;
                return _gameObject;
            }
            set
            {
                if(!_gameObject&&!destroyed)
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
                if (destroyed)
                    return null;
                return _transform;
            }
        }
        private Transform _transform;

        abstract public void Awake();
        abstract public void Start();
        abstract public void OnEnable();
        abstract public void OnDisable();
        abstract public void OnDestroy();

        public void Destroy()
        {
            OnDestroy();
            destroyed = true;
            _gameObject = null;
            _transform = null;
        }
    }
}
