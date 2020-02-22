using System.Numerics;

namespace Fingear.Inputs.Base
{
    public abstract class CursorInputBase : PositionInputBase<Vector2>, ICursorInput
    {
        public abstract Vector2 Maximum { get; }
        public abstract Vector2 Minimum { get; }
        public Vector2 Delta => Value - LastValue;
    }
}