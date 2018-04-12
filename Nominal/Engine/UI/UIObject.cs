using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine.UI
{
    public abstract class UIObject : Object
    {
        #region StaticVars

        static List<UIObject> uiObjects = new List<UIObject>();
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

        public UIObject parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        private UIObject _parent = null;

        private List<UIObject> children = new List<UIObject>();

        public DVector2 anchorMax
        {
            get
            {
                return _anchorMax;
            }
            set
            {
                if (value != null)
                    _anchorMax = value;
            }
        }
        private DVector2 _anchorMax = DVector2.zero;

        public DVector2 anchorMin
        {
            get
            {
                return _anchorMin;
            }
            set
            {
                if (value != null)
                    _anchorMin = value;
            }
        }
        private DVector2 _anchorMin = DVector2.zero;

        public DVector2 offsetMax
        {
            get
            {
                return _offsetMax;
            }
            set
            {
                if (value != null)
                    _offsetMax = value;
            }
        }
        private DVector2 _offsetMax = DVector2.zero;

        public DVector2 offsetMin
        {
            get
            {
                return _offsetMin;
            }
            set
            {
                if (value != null)
                    _offsetMin = value;
            }
        }

        private DVector2 _offsetMin = DVector2.zero;

        #endregion

        #region Constructors

        public UIObject()
        {
            if(onClear)
            {
                Destroy(this);
                return;
            }
            uiObjects.Add(this);
        }

        #endregion

        #region StaticFuncs

        public static void ClearAll()
        {
            _onClear = true;
            if (!GameObject.onClear)
                GameObject.ClearAll();
        }

        #endregion

        #region NonStaticFuncs

        override protected sealed void Destroy()
        {
            base.Destroy();// hier wird die base zerstört
        }
        public void SetAnchorPreset(AnchorPreset preset)
        {
            int num = (int)preset;
            int[] vals = new int[2];
            vals[0] = num % 4;
            vals[1] = (int)Math.Floor(num / 4.0f);
            for(int i = 0; i<2; i++)
            {
                double min = 0;
                double max = 0;
                
                switch(vals[0])
                {
                    case 0:
                        {
                            min = 0.5;
                            max = 0.5;
                            break;
                        }
                    case 1:
                        {
                            min = 0;
                            max = 0;
                            break;
                        }
                    case 2:
                        {
                            min = 1;
                            max = 1;
                            break;
                        }
                    case 3:
                        {
                            min = 0;
                            max = 1;
                            break;
                        }
                }
                if(i==0)
                {
                    anchorMax.X = max;
                    anchorMin.X = min;
                }
                else
                {
                    anchorMax.Y = max;
                    anchorMin.Y = min;
                }
            }
        }
        #endregion
    }
}