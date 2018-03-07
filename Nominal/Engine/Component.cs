using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public abstract class Component : Object, IDestroyable
    {
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
        abstract public override void OnEnable();
        abstract public override void OnDisable();
        abstract public void OnDestroy();

        public override void Destroy()
        {
            OnDestroy();
            destroyed = true;
            _gameObject = null;
            _transform = null;
        }

        public static implicit operator bool(Component component)
        {
            return component == null ? false : !component.destroyed;
        }
    }
}
