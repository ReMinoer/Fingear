using System.Numerics;
using Fingear.Inputs;

namespace Fingear.MonoGame.Inputs
{
    public class MouseCursorInput : CursorInputBase
    {
        public override string DisplayName => "Mouse";
        public override IInputSource Source => MonoGameInputSytem.Instance.Mouse;
        public override Vector2 Value => MonoGameInputSytem.Instance.InputStates.MouseState.Position.AsFingearVector();
        public override Vector2 Maximum => new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        public override Vector2 Minimum => Vector2.Zero;

        internal MouseCursorInput()
        {
        }
    }
}