using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nominal.Engine
{
    static class InputManager
    {
        public static int length = Enum.GetNames(typeof(Keys)).Length;
        static KeyboardState oldState;

        static MouseState oldMouseState;

        public static void LateUpdate()
        {
            oldState = Keyboard.GetState();
            oldMouseState = Mouse.GetState();
        }
        public static bool GetKey(Keys k)
        {
            return Keyboard.GetState().IsKeyDown(k);
        }
        public static bool GetKeyDown(Keys k)
        {
            return Keyboard.GetState().IsKeyDown(k) && oldState.IsKeyUp(k);
        }
        public static bool GetKeyUp(Keys k)
        {
            return Keyboard.GetState().IsKeyUp(k) && oldState.IsKeyDown(k);
        }

        public static int mouseDelta
        {
            get
            {
                return Mouse.GetState().ScrollWheelValue - oldMouseState.ScrollWheelValue;
            }
        }
        
        public static DVector2 mousePosition
        {
            get
            {
                return new DVector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            }
        }

        public static bool mouseClicked
        {
            get
            {
                return (Mouse.GetState().LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != Mouse.GetState().LeftButton);
            }
        }

    }
}
