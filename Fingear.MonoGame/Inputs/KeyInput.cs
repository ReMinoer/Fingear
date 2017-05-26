using Fingear.Inputs;
using Fingear.Utils;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public class KeyInput : ButtonInputBase
    {
        public Keys Key { get; }
        public override string DisplayName => EnumUtils.GetDisplayName(Key);
        public override IInputSource Source => MonoGameInputSytem.Instance.Keyboard;
        public override bool Value => MonoGameInputSytem.Instance.InputStates.KeyboardState.IsKeyDown(Key);

        internal KeyInput(Keys key)
        {
            Key = key;
        }
    }
}