using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public sealed class GameObject : Object, IDestroyable
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

        public string name
        {
            get
            {
                if (destroyed)
                    return null;
                return _name;
            }
            set
            {
                if (destroyed)
                    return;
                _name = value;
            }
        }
        private string _name;

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
            if (destroyed)
                return null;
            return FindChildren(name).FirstOrDefault();
        }
        public IEnumerable<GameObject> FindChildren(string name)
        {
            if (destroyed)
                return null;
            return children.Where(x => x.name == name);
        }

        public override void Destroy()
        {
            if (destroyed)
                return;
            parent = null;
            _tranform = null;
            destroyed = true;
            if(hierarchy.Contains(this))
                hierarchy.Remove(this);
            components.ForEach(x => x.Destroy());
            children.ForEach(x => x.Destroy());
        }

        private void Update()
        {
            if (destroyed||!enabled)
                return;
            components.Where(x => x is IUpdateable).Select(x => (IUpdateable)x).ToList().ForEach(x => x.Update());
            children.ForEach(x => x.Update());
        }
        private void Draw(SpriteBatch spriteBatch)
        {
            if (destroyed||!enabled)
                return;
            components.Where(x => x is IDrawable).Select(x => (IDrawable)x).ToList().ForEach(x => x.Draw(spriteBatch));
            children.ForEach(x => x.Draw(spriteBatch));
        }

        //TODO: Fix some bugs which will probably occour with OnEnable and OnDisable
        public override void OnEnable()
        {
            components.ForEach(x => { if (x.enabled) { x.OnEnable(); } });
            children.ForEach(x => { if (x.enabled) { x.OnEnable(); } });
        }
        public override void OnDisable()
        {
            components.ForEach(x => { if (x.enabled) { x.OnDisable(); } });
            children.ForEach(x => { if (x.enabled) { x.OnDisable(); } });
        }
        #endregion

        #region StaticFuncs
        public static implicit operator bool(GameObject gameObject)
        {
            return gameObject==null ? false : !gameObject.destroyed;
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

        public static void UpdateObjects()
        {
            hierarchy.Where(x => x.parent == null).ToList().ForEach(x => x.Update());
        }
        public static void DrawObjects(SpriteBatch spriteBatch)
        {
            hierarchy.Where(x => x.parent == null).ToList().ForEach(x => x.Draw(spriteBatch));
        }
        #endregion
    }
}
