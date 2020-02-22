using Fingear.Inputs;
using Fingear.Inputs.Base;
using Fingear.Utils;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public class KeyInput : ButtonInputBase
    {
        public Keys Key { get; }
        public override string DisplayName => EnumUtils.GetDisplayName(Key);
        public override IInputSource Source => InputSystem.Instance.Keyboard;
        public override bool Value => InputSystem.Instance.InputStates.KeyboardState.IsKeyDown(Key);

        internal KeyInput(Keys key)
        {
            Key = key;
        }
    }
}