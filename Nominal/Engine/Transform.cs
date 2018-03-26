using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public enum TransformSpace
    {
        Local,
        World
    }
    public class Transform : Container
    {
        public DVector2 position
        {
            get
            {
                if (isDestroyed)
                    return null;
                return parent ? parent.position + localPosition : localPosition;
            }
            set
            {
                if (isDestroyed)
                    return;
                _localPosition = parent ? value - parent.position : value;
            }
        }
        public DVector2 localPosition
        {
            get
            {
                if (isDestroyed)
                    return null;
                return _localPosition;
            }
            set
            {
                _localPosition = value;
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

        private DVector2 _localPosition;
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

        public Transform FindChild(string name, bool searchRecursivly = false)
        {
            if (!searchRecursivly)
            {
                return children.Find(x => x.gameObject.name == name);
            }
            else
            {
                if (children.Count == 0)
                    return null;
                var child = children.Select(x => x.gameObject.name == name ? x : (x.FindChild(name, true)));
                if (child.Count() == 0)
                    return null;
                return child.First();
            }
        }
        public List<Transform> FindChildren(string name, bool searchRecursivly = false)
        {
            if (!searchRecursivly)
            {
                return children.FindAll(x => x.gameObject.name == name).ToList();
            }
            else
            {
                if (children.Count == 0)
                    return null;
                return children.Select(x => x.gameObject.name == name ? x : (x.FindChild(name, true))).ToList();
            }
        }

        protected override void Destroy()
        {
            if (gameObject)
            {             
                Destroy(gameObject);
                return;
            }
            base.Destroy();
            children.ForEach(x => Destroy(x.gameObject));
            children.Clear();
            _localPosition = null;
            _size = null;
            _parent = null;
        }

        static void SetChild(Transform curr, Transform from, Transform to)
        {
            DVector2 relPos = GetRelativePos(from, to) + curr.localPosition;
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
            curr.localPosition = relPos;
        }

        /// <summary>
        /// Calculates the relative Position between between two Transforms.
        /// </summary>
        public static DVector2 GetRelativePos(Transform a, Transform b)
        {
            Transform comPar = GetCommonParent(a, b);
            DVector2 aVec = GetRelativePosToParent(a, comPar);
            DVector2 bVec = GetRelativePosToParent(b, comPar);
            return aVec != null && bVec != null ? aVec - bVec : null;
        }
        /// <summary>
        /// Calculates the relative Position between the child and a distant parent par. Returns null if par is not in the parent line of child.
        /// </summary>
        public static DVector2 GetRelativePosToParent(Transform child, Transform par)
        {
            DVector2 relPos = DVector2.zero;
            
            Transform curr = child;

            while (curr)
            {
                if (curr == par)
                    return relPos;
                relPos += curr.localPosition;
                curr = curr.parent;
            }

            if (curr == par)
                return relPos;
            return null;
        }
        /// <summary>
        /// Returns the common parent of the Transforms a and b. Returns null if there is no common parent.
        /// </summary>
        public static Transform GetCommonParent(Transform a, Transform b)
        {
            List<Transform> aParents = new List<Transform>();
            Transform curr = a;
            while(curr)
            {
                aParents.Add(curr);
                curr = curr.parent;
            }
            curr = b;
            while(curr)
            {
                if (aParents.Contains(curr))
                    return curr;
                curr = curr.parent;
            }
            return null;
        }
    }
}
