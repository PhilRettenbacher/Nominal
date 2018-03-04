using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public sealed class GameObject : IDestroyable
    {
        #region StaticVars
        //List of all GOs in Game
        static List<GameObject> hierarchy = new List<GameObject>();
        #endregion

        #region NonStaticVars
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

        public string name;

        public GameObject parent
        {
            get
            {
                if (destroyed)
                    return null;
                return _parent;
            }
            set
            {
                if(_parent != value&&!destroyed)
                {
                    SetChild(this, _parent, value);
                    _parent = value;
                }
            }
        }
        private GameObject _parent;

        private bool destroyed;

        private List<Component> components = new List<Component>();
        private List<GameObject> children = new List<GameObject>();
        #endregion

        #region Constructors
        public GameObject()
        {
            _tranform = new Transform();
            _tranform.position = DVector2.zero;
            _tranform.rotation = 0;
            _tranform.size = DVector2.uniform;

            name = "New GO";

            hierarchy.Add(this);
        }
        #endregion

        #region NonStaticFuncs

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

        public GameObject FindChild(string name)
        {
            return FindChildren(name).FirstOrDefault();
        }
        public IEnumerable<GameObject> FindChildren(string name)
        {
            return children.Where(x => x.name == name);
        }

        public void Destroy()
        {
            parent = null;
            _tranform = null;
            destroyed = true;
            if(hierarchy.Contains(this))
                hierarchy.Remove(this);
            components.ForEach(x => x.Destroy());
            children.ForEach(x => x.Destroy());
        }
        #endregion

        #region StaticFuncs
        public static implicit operator bool(GameObject gameObject)
        {
            return gameObject==null ? false : gameObject != gameObject.destroyed;
        }

        //(Re)sets child (curr), from the current GO (from) to the new GO (to)
        static void SetChild(GameObject curr, GameObject from, GameObject to)
        {
            if(from)
            {
                from.children.Remove(curr);
            }
            if(to)
            {
                to.children.Add(curr);
            }
        }

        public static IEnumerable<GameObject> FindGameObjects(string name)
        {
            return hierarchy.Where(x => x.name == name);
        }
        public static GameObject FindGameObject(string name)
        {
            return FindGameObjects(name).FirstOrDefault();
        }
        #endregion
    }
}
