using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public sealed class GameObject : Object
    {
        #region StaticVars
        //List of all GOs in Game
        static List<GameObject> objects = new List<GameObject>();
        static List<Component> toStart = new List<Component>();

        public static bool onClear
        {
            get
            {
                return _onClear;
            }
        }
        static private bool _onClear = false;
        #endregion

        #region NonStaticVars
        public Transform transform
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _transform;
            }
        }
        private Transform _transform;

        public string name
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _name;

        private List<Component> components = new List<Component>();
        #endregion

        #region Constructors
        public GameObject()
        {
            _transform = new Transform();
            _transform.position = DVector2.zero;
            _transform.rotation = 0;
            _transform.size = DVector2.uniform;
            _transform.gameObject = this;

            name = "New GO";

            if (_onClear)
            {
                Console.WriteLine("Objects can't be instantiated while clearing the Scene");
                Destroy(this);
                return;
            }
            objects.Add(this);
        }
        #endregion

        #region NonStaticFuncs

        public T AddComponent<T>() where T : Component, new()
        {
            if (isDestroyed)
                return null;
            if(_onClear)
            {
                Console.WriteLine("Objects can't be instantiated while clearing the Scene");
                return null;
            }
            T component = new T();
            if(((Component)component) is IUniqueComponent)
            {
                if(GetComponent<T>())
                {
                    System.Console.WriteLine("There already exists a Component of Type " + typeof(T) + " on this Object!");
                    return null;
                }
            }
            component.gameObject = this;
            component.transform = transform;
            components.Add(component);
            toStart.Add(component);
            component.Awake();
            return component;
        }
        public T GetComponent<T>() where T : Component
        {
            if (isDestroyed)
                return null;
            var comps = components.Where(x => typeof(T).Equals(x.GetType()));

            if (comps.Count() > 0)
                return (T)comps.First();
            else
                return null;
        }

        public void RemoveComponent(Component toRemove)
        {
            if (toStart.Contains(toRemove))
                toStart.Remove(toRemove);
            if (components.Contains(toRemove))
            {
                components.Remove(toRemove);
            }
            if (!toRemove.isDestroyed)
            {
                Destroy(toRemove);
                return;
            }
        }

        override protected void Destroy()
        {
            base.Destroy();
            for(int i = components.Count-1; i>=0; i--)
            {
                Destroy(components[i]);
            }
            
            Destroy(_transform);
            
            if (objects.Contains(this))
                objects.Remove(this);
        }

        private void Update()
        {
            if (!_onClear)
            {
                var startList = new List<Component>(toStart);
                toStart.Clear();
                startList.ForEach(x => x.Start());
                var updateList = components.Where(x => x is IUpdateable).ToList();
                updateList.ForEach(x => ((IUpdateable)x).Update());
            }
        }
        private void Draw(DrawHelper drawBuffer)
        {
            if (!_onClear)
            {
                var drawList = components.Where(x => x is IDrawable).ToList();
                drawList.ForEach(x => ((IDrawable)x).Draw(drawBuffer));
            }
        }
        #endregion

        #region StaticFuncs

        public static IEnumerable<GameObject> FindObjects(string name)
        {
            return objects.Where(x => x.name.Equals(name));
        }
        public static GameObject FindObject(string name)
        {
            return objects.Find(x => x.name.Equals(name));
        }

        public static void ClearAll()
        {
            Console.WriteLine("ClearAll");
            _onClear = true;
        }

        public static void UpdateObjects()
        {
            if (!_onClear)
            {
                var updateList = new List<GameObject>(objects);
                updateList.ForEach(x => x.Update());
            }
            else
            {
                Console.WriteLine("ClearAll!");
                var gmList = new List<GameObject>(objects);
                gmList.ForEach(x => Destroy(x));
                _onClear = false;
            }
        }
        public static void DrawObjects(SpriteBatch spriteBatch)
        {
            if (!_onClear)
            {
                DrawHelper drawHelper = new DrawHelper(spriteBatch);
                var drawList = new List<GameObject>(objects);
                drawList.ForEach(x => x.Draw(drawHelper));
            }
        }
        #endregion
    }
}
