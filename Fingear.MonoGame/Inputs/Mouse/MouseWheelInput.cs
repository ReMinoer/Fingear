using Fingear.Inputs;

namespace Fingear.MonoGame.Inputs.Mouse
{
    public class MouseWheelInput : ScaleInputBase
    {
        public override string DisplayName => "Mouse Wheel";
        public override IInputSource Source => new MouseSource();
        public override float Value => InputStates.Instance.MouseState.ScrollWheelValue;
        public override float Maximum => float.PositiveInfinity;
        public override float Minimum => float.NegativeInfinity;
    }
}