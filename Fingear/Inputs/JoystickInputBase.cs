using System.Numerics;
using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class JoystickInputBase : ForceInputBase<Vector2>, IJoystickInput
    {
        public abstract Vector2 Maximum { get; }
        public abstract Vector2 Minimum { get; }
        public Vector2 Delta => Value - LastValue;
    }
}