using System.Numerics;
using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class CursorInputBase : ContinousInputBase<Vector2>, ICursorInput
    {
        public abstract Vector2 Maximum { get; }
        public abstract Vector2 Minimum { get; }
        public Vector2 Delta => Value - LastValue;
    }
}