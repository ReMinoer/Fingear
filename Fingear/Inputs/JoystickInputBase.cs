using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class JoystickInputBase : PonctualInputBase<Vector2>, IJoystickInput
    {
        public abstract Vector2 Maximum { get; }
        public abstract Vector2 Minimum { get; }
    }
}