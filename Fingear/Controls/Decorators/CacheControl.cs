using Fingear.Controls.Base;

namespace Fingear.Controls.Decorators
{
    public class CacheControl<TControl> : ControlDecoratorBase<TControl>
        where TControl : class, IControl
    {
        private float _timeout;
        private float _timeoutElapsed;

        public float Timeout
        {
            get { return _timeout; }
            set
            {
                _timeout = value;
                _timeoutElapsed = 0;
            }
        }

        public CacheControl()
        {
        }

        public CacheControl(TControl control, float timeout)
        {
            Component = control;
            Timeout = timeout;
        }

        public CacheControl(string name, TControl control, float timeout)
            : this(control, timeout)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            if (Component.IsActive)
                _timeoutElapsed = 0;
            else
                _timeoutElapsed += elapsedTime;

            return _timeoutElapsed <= Timeout;
        }
    }

    public class CacheControl<TControl, TValue> : ControlDecoratorBase<TControl, TValue>
        where TControl : class, IControl<TValue>
    {
        private float _timeout;
        private float _timeoutElapsed;
        private TValue _lastValue;

        public float Timeout
        {
            get { return _timeout; }
            set
            {
                _timeout = value;
                _timeoutElapsed = 0;
            }
        }

        public CacheControl()
        {
        }

        public CacheControl(TControl control, float timeout)
        {
            Component = control;
            Timeout = timeout;
        }
        
        protected override bool UpdateControlValue(float elapsedTime, out TValue value)
        {
            TValue currentValue;
            if (Component.IsActive(out currentValue))
            {
                _lastValue = currentValue;
                _timeoutElapsed = 0;
            }
            else
                _timeoutElapsed += elapsedTime;

            value = _lastValue;
            return _timeoutElapsed <= Timeout;
        }
    }
}