using System;
using Fingear.Inputs;
using Fingear.Inputs.Base;
using Fingear.Utils;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public enum MouseButton
    {
        Left,
        Right,
        Middle,
        XButton1,
        XButton2
    }

    public class MouseButtonInput : ButtonInputBase
    {
        public MouseButton Button { get; }
        public override string DisplayName => EnumUtils.GetDisplayName(Button);
        public override IInputSource Source => InputSystem.Instance.Mouse;

        public override bool Value
        {
            get
            {
                MouseState mouseState = InputSystem.Instance.InputStates.MouseState;
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

        internal MouseButtonInput(MouseButton button)
        {
            Button = button;
        }
    }
}