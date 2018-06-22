using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        //Needed for Screencalculations
        public const int REFERENCE_SCREEN_HEIGHT = 1080;
        public const int REFERENCE_SCREEN_WIDTH = 1920;
        public const bool USE_REFERENCE_SCREEN_WIDTH = true;

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

        public Point offsetMax
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
        private Point _offsetMax = Point.Zero;

        public Point offsetMin
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
        private Point _offsetMin = Point.Zero;

        #endregion

        #region Constructors

        public UIObject()
        {
            if (onClear)
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

        public static void DrawUI(SpriteBatch spriteBatch)
        {
            if (!_onClear)
            {
                DrawHelper drawHelper = new DrawHelper(spriteBatch);
                var toDraw = uiObjects.Where(x => x is IDrawable).ToList();
                toDraw.ForEach(x => ((IDrawable)x).Draw(drawHelper));
            }
        }
        public static void UpdateUI()
        {
            if (_onClear)
            {
                Console.WriteLine("ClearAll!");
                var gmList = new List<UIObject>(uiObjects);
                gmList.ForEach(x => Destroy(x));
                _onClear = false;
            }
        }

        #endregion

        #region NonStaticFuncs

        override protected sealed void Destroy()
        {
            base.Destroy();// hier wird die base zerstört
            if (uiObjects.Contains(this))
                uiObjects.Remove(this);
        }
        public void SetAnchorPreset(AnchorPreset preset)
        {
            int num = (int)preset;
            int[] vals = new int[2];
            vals[0] = num % 4;
            vals[1] = (int)Math.Floor(num / 4.0f);
            for (int i = 0; i < 2; i++)
            {
                double min = 0;
                double max = 0;

                switch (vals[i])
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
                if (i == 0)
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
        /// <summary>
        /// Returns the Screen Rectangle of this UIObject in Reference Screen Coordinates
        /// </summary>
        protected Rectangle GetViewRect()
        {
            //Nope, this not how we do it

            //Wait, this is exactly how we do it!
            //DEW IT
            //YEAH

            Rectangle currRect = new Rectangle();
            Rectangle parRect = new Rectangle();
            if (parent)
            {
                parRect = parent.GetViewRect();
            }
            else
            {
                parRect = new Rectangle(0, 0, (int)DrawHelper.screenSize.X, (int)DrawHelper.screenSize.Y);
            }
            float offsetFactor = USE_REFERENCE_SCREEN_WIDTH ? DrawHelper.screenSize.X / (float)REFERENCE_SCREEN_WIDTH : DrawHelper.screenSize.Y / (float)REFERENCE_SCREEN_HEIGHT;
            int x = (int)(anchorMin.X * parRect.Width) + parRect.X + (int)(offsetMin.X*offsetFactor);
            int y = (int)(anchorMin.Y * parRect.Height) + parRect.Y + (int)(offsetMin.Y*offsetFactor);

            int width = (int)(anchorMax.X * parRect.Width) + parRect.X + (int)(offsetMax.X*offsetFactor) - x;
            int height = (int)(anchorMax.Y * parRect.Height) + parRect.Y + (int)(offsetMax.Y*offsetFactor) - y;

            currRect = new Rectangle(x, y, width, height);

            return currRect;
        }
        #endregion
    }
}