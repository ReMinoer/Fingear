using System;

namespace Fingear.Inputs.Base
{
    public abstract class PositionInputBase<TValue> : InputBase<TValue>, IPositionInput<TValue>
        where TValue : IEquatable<TValue>
    {
        protected override InputActivity UpdateActivity(TValue value)
        {
            var inputActivity = InputActivity.Idle;

            if (!value.Equals(LastValue))
                inputActivity |= InputActivity.Pressed;
            if (inputActivity.IsPressed() != Activity.IsPressed())
                inputActivity |= InputActivity.Changed;

            return inputActivity;
        }
    }
}