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

            objects.Add(this);
        }
        #endregion

        #region NonStaticFuncs

        public T AddComponent<T>() where T : Component, new()
        {
            if (isDestroyed)
                return null;
           
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
            if(!toRemove.isDestroyed)
            {
                Destroy(toRemove);
                return;
            }
            if(components.Contains(toRemove))
            {
                components.Remove(toRemove);
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
            components.Where(x => !x.isInitialized).ToList().ForEach(x => x.isInitialized = true);
            components.Where(x => x is IUpdateable && x.isInitialized).ToList().ForEach(x => ((IUpdateable)x).Update());
        }
        private void Draw(DrawHelper drawBuffer)
        {
            components.Where(x => x is IDrawable).ToList().ForEach(x => ((IDrawable)x).Draw(drawBuffer));
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

        public static void UpdateObjects()
        {
            objects.ForEach(x => x.Update());
        }
        public static void DrawObjects(SpriteBatch spriteBatch)
        {
            DrawHelper drawHelper = new DrawHelper(spriteBatch);
            objects.ForEach(x => x.Draw(drawHelper));
            //drawHelper.Finish();
        }
        #endregion
    }
}
