using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs.Mouse
{
    public class MouseButtonInput : ButtonInputBase
    {
        public MouseButton Button { get; }
        public override IInputSource Source => new MouseSource();

        public override bool Value
        {
            get
            {
                MouseState mouseState = InputStates.Instance.MouseState;
                switch (Button)
                {
                    case MouseButton.Left: return mouseState.LeftButton == ButtonState.Pressed;
                    case MouseButton.Right: return mouseState.RightButton == ButtonState.Pressed;
                    case MouseButton.Middle: return mouseState.MiddleButton == ButtonState.Pressed;
                    case MouseButton.XButton1: return mouseState.XButton1 == ButtonState.Pressed;
                    case MouseButton.XButton2: return mouseState.XButton2 == ButtonState.Pressed;
                    default: throw new NotSupportedException();
                }
            }
        }

        public MouseButtonInput(MouseButton button)
        {
            Button = button;
        }
    }
}