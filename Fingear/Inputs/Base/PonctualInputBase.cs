using System;

namespace Fingear.Inputs.Base
{
    public abstract class PonctualInputBase<TValue> : IPunctualInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract TValue IdleValue { get; }
        public abstract IInputSource Source { get; }
        protected TValue LastValue { get; private set; }

        public void Update()
        {
            TValue value = Value;
            TValue idleValue = IdleValue;

            bool isIdle = value.Equals(idleValue);
            bool hasChanged = !value.Equals(LastValue);

            if (isIdle)
                Activity = hasChanged ? InputActivity.Released : InputActivity.Idle;
            else
                Activity = hasChanged ? InputActivity.Triggered : InputActivity.Pressed;

            LastValue = value;
        }
    }
}