using Fingear.Inputs;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs.Keyboard
{
    public class KeyInput : ButtonInputBase
    {
        public Keys Key { get; }
        public override IInputSource Source => new KeyboardSource();
        public override bool Value => InputStates.Instance.KeyboardState.IsKeyDown(Key);

        public KeyInput(Keys key)
        {
            Key = key;
        }
    }
}