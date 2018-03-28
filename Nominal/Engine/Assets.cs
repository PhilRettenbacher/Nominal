using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    public static class Assets
    {
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public static void Initialize(GraphicsDevice graphics)
        {
            Texture2D text = new Texture2D(graphics, 1, 1);
            Color[] data = new Color[1];
            for (int i = 0; i < 1; i++)
            {
                data[i] = Color.White;
            }
            text.SetData(data);

            textures.Add("placeholder001", text);
        }
        public static Texture2D GetTexture(string key)
        {
            if(textures.ContainsKey(key))
            {
                return textures[key];
            }
            return null;
        }
    }
}
