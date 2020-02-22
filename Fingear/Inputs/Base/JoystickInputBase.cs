using System.Numerics;

namespace Fingear.Inputs.Base
{
    public abstract class JoystickInputBase : ForceInputBase<Vector2>, IJoystickInput
    {
        public abstract Vector2 Maximum { get; }
        public abstract Vector2 Minimum { get; }
        public Vector2 Delta => Value - LastValue;
    }
}