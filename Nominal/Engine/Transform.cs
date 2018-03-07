using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public class Transform : Container
    {
        public DVector2 position
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _position;
            }
            set
            {
                if (isDestroyed)
                    return;
                _position = value;
            }
        }
        public DVector2 size
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _size;
            }
            set
            {
                if (isDestroyed)
                    return;
                _size = value;
            }
        }
        public double rotation
        {
            get
            {
                if (isDestroyed)
                    return 0;
                return _rotation;
            }
            set
            {
                if (isDestroyed)
                    return;
                _rotation = value;
            }
        }

        private DVector2 _position;
        private DVector2 _size;
        private double _rotation;

        private List<Transform> children = new List<Transform>();

        public Transform parent
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _parent;
            }
            set
            {
                if (isDestroyed)
                    return;
                SetChild(this, _parent, value);
            }
        }
        private Transform _parent;

        protected override void Destroy()
        {
            System.Console.WriteLine("BeforeGO " + (gameObject==null));
            if (gameObject)
            {             
                Destroy(gameObject);
                return;
            }
            base.Destroy();
            children.ForEach(x => Destroy(x.gameObject));
            children.Clear();
            position = null;
            size = null;
            gameObject = null;
            _parent = null;
        }

        static void SetChild(Transform curr, Transform from, Transform to)
        {
            curr._parent = to;
            if(from)
            {
                if (from.children.Contains(curr))
                    from.children.Remove(curr);
            }
            if(to)
            {
                to.children.Add(curr);
            }
        }
    }
}
