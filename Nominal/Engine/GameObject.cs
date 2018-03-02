using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public sealed class GameObject : IDestroyable
    {
        public Transform transform
        {
            get
            {
                if (destroyed)
                    return null;
                return _tranform;
            }
        }
        private Transform _tranform;

        private bool destroyed;

        private List<Component> components = new List<Component>();

        public GameObject()
        {
            _tranform = new Transform();
            _tranform.position = DVector2.zero;
            _tranform.rotation = 0;
            _tranform.size = DVector2.uniform;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            if (destroyed)
                return null;
            T component = new T();
            component.gameObject = this;
            components.Add(component);
            component.Awake();
            return component;
        }
        public T GetComponent<T>() where T : Component
        {
            if (destroyed)
                return null;
            var comps = components.Where(x => typeof(T).Equals(x));
            if (comps.Count() > 0)
                return (T)comps.First();
            else
                return null;
        }

        public void Destroy()
        {
            _tranform = null;
            components.ForEach(x => x.Destroy());
        }

        public static implicit operator bool(GameObject gameObject)
        {
            return gameObject != gameObject.destroyed;
        }
    }
}
