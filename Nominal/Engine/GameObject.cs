using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public sealed class GameObject
    {
        public Transform transform
        {
            get
            {
                return _tranform;
            }
        }
        private Transform _tranform;

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
            T component = new T();
            component.gameObject = this;
            components.Add(component);
            return component;
        }
        public T GetComponent<T>() where T : Component
        {
            var comps = components.Where(x => typeof(T).Equals(x));
            if (comps.Count() > 0)
                return (T)comps.First();
            else
                return null;
        }

        public static implicit operator bool(GameObject gameObject)
        {
            return gameObject != null;
        }
    }
}
