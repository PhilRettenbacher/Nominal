using Nominal.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Components.Cam
{
    public class CameraRect
    {
        public DVector2 position;
        public double size;
        public double rotation;

        public CameraRect (DVector2 _position, double _size, double _rotation)
        {
            position = _position;
            size = _size;
            rotation = _rotation;
        }
    }
}
