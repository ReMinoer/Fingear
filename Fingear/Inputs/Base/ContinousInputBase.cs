using System;

namespace Fingear.Inputs.Base
{
    public abstract class ContinousInputBase<TValue> : IContinuousInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private TValue _lastValue;
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract IInputSource Source { get; }

        public void Update()
        {
            InputActivity lastActivity = Activity;
            TValue value = Value;

            bool hasValueChanged = !value.Equals(_lastValue);
            Activity = hasValueChanged ? InputActivity.Pressed : InputActivity.Idle;
            
            bool hasActivityChanged = Activity.IsPressed() != lastActivity.IsPressed();
            if (hasActivityChanged)
                Activity = hasValueChanged ? InputActivity.Triggered : InputActivity.Released;

            _lastValue = value;
        }
    }
}