using System;

namespace Fingear.Inputs.Base
{
    public abstract class ForceInputBase<TValue> : InputBase<TValue>, IForceInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract TValue IdleValue { get; }

        protected override InputActivity UpdateActivity(TValue value)
        {
            var activity = InputActivity.Idle;

            if (!value.Equals(IdleValue))
                activity |= InputActivity.Pressed;
            if (!value.Equals(IdleValue))
                activity |= InputActivity.Changed;

            return activity;
        }
    }
}