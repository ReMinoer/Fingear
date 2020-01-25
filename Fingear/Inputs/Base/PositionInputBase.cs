using System;

namespace Fingear.Inputs.Base
{
    public abstract class PositionInputBase<TValue> : InputBase<TValue>, IPositionInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private bool _initialized;

        public override void Prepare()
        {
            base.Prepare();

            if (_initialized)
                return;
            
            CurrentValue = Value;
            LastValue = Value;
            _initialized = true;
        }

        protected override InputActivity UpdateActivity(TValue value)
        {
            var inputActivity = InputActivity.Idle;

            if (!value.Equals(LastValue))
                inputActivity |= InputActivity.Pressed;
            if (inputActivity.IsPressed() != Activity.IsPressed())
                inputActivity |= InputActivity.Changed;

            return inputActivity;
        }

        public override void Reset()
        {
            base.Reset();
            _initialized = false;
        }
    }
}