using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class ForceInputBase<TValue> : InputBase<TValue>, IForceInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract TValue IdleValue { get; }

        protected override InputActivity UpdateActivity(TValue value)
        {
            return InputActivityUtils.UpdatePonctual(value, LastValue, IdleValue);
        }
    }
}