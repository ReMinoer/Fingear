using System;

namespace Fingear.Inputs.Base
{
    public abstract class ContinousInputBase<TValue> : IContinuousInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract IInputSource Source { get; }
        protected TValue LastValue { get; private set; }

        public void Update()
        {
            InputActivity lastActivity = Activity;
            TValue value = Value;

            bool hasValueChanged = !value.Equals(LastValue);
            Activity = hasValueChanged ? InputActivity.Pressed : InputActivity.Idle;
            
            bool hasActivityChanged = Activity.IsPressed() != lastActivity.IsPressed();
            if (hasActivityChanged)
                Activity = hasValueChanged ? InputActivity.Triggered : InputActivity.Released;
            
            LastValue = value;
        }
    }
}