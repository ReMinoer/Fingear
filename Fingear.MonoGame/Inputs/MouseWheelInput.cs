using Fingear.Inputs;
using Fingear.Inputs.Base;

namespace Fingear.MonoGame.Inputs
{
    public class MouseWheelInput : ScaleInputBase
    {
        public override string DisplayName => "Mouse Wheel";
        public override IInputSource Source => InputSystem.Instance.Mouse;
        public override float Value => InputSystem.Instance.InputStates.MouseState.ScrollWheelValue;
        public override float Maximum => int.MaxValue;
        public override float Minimum => int.MinValue;

        internal MouseWheelInput()
        {
        }
    }
}