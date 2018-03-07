using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public static class Time
    {
        public static GameTime gameTimeUpdate;
        public static GameTime gameTimeDraw;

        public static double deltaTimeUpdate
        {
            get
            {
                return gameTimeUpdate.ElapsedGameTime.TotalSeconds;
            }
        }
        public static double time
        {
            get
            {
                return gameTimeUpdate.TotalGameTime.TotalSeconds;
            }
        }
        public static double deltaTimeDraw
        {
            get
            {
                return gameTimeDraw.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
