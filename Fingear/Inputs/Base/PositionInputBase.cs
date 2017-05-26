using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class PositionInputBase<TValue> : InputBase<TValue>, IPositionInput<TValue>
        where TValue : IEquatable<TValue>
    {
        protected override InputActivity UpdateActivity(TValue value)
        {
            return InputActivityUtils.UpdateContinous(value, LastValue, Activity);
        }
    }
}