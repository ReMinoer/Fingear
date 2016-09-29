using Fingear.Controls.Base;

namespace Fingear.Controls.Decorators
{
    public class DelayControl<TControl> : ControlDecoratorBase<TControl>
        where TControl : class, IControl
    {
        private float _totalElapsedTime;
        public float Timer { get; set; }

        public DelayControl()
        {
        }

        public DelayControl(TControl control, float timer)
        {
            Component = control;
            Timer = timer;
        }

        public DelayControl(string name, TControl control, float timer)
            : this(control, timer)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            if (Component != null && Component.IsActive())
            {
                _totalElapsedTime += elapsedTime;
                if (_totalElapsedTime > Timer)
                    return true;
            }

            _totalElapsedTime = 0;
            return false;
        }
    }

    public class DelayControl<TControl, TValue> : ControlDecoratorBase<TControl, TValue>
        where TControl : class, IControl<TValue>
    {
        private float _totalElapsedTime;
        public float Timer { get; set; }

        public DelayControl()
        {
        }

        public DelayControl(TControl control, float timer)
        {
            Component = control;
            Timer = timer;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            if (Component != null && Component.IsActive(out value))
            {
                _totalElapsedTime += elapsedTime;
                return _totalElapsedTime > Timer;
            }

            _totalElapsedTime = 0;
            value = default(TValue);
            return false;
        }
    }
}