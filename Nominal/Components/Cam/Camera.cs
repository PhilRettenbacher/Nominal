using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Components.Cam
{
    class Camera : Component
    {
        public static Camera mainCamera;
        public static GraphicsDeviceManager graphics;

        /// <summary>
        /// In meters.
        /// </summary>
        public float cameraSize = 1; 

        public override void Awake()
        {
            if (!mainCamera)
                mainCamera = this;
        }
        public override void OnDestroy()
        {
            
        }
        public override void Start()
        {
            
        }
        public CameraRect Translate(Transform curr)
        {
            //TODO: finish

            DVector2 pos = Transform.GetRelativePos(curr, transform)/cameraSize;
            DVector2 size = curr.size / cameraSize;

            CameraRect rect = new CameraRect(pos, size.X, transform.rotation);
            return rect;
        }
    }
}
