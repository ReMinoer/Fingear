using Diese;

namespace Fingear.Controls.Base
{
    public class ControlImplementation
    {
        private readonly IControlWrapper _wrapper;
        public bool IsTriggered { get; protected set; }
        public string Name { get; set; }

        public ControlImplementation(IControlWrapper wrapper)
        {
            _wrapper = wrapper;
            Name = GetType().GetDisplayName();
        }

        public virtual void Update(float elapsedTime)
        {
            IsTriggered = _wrapper.UpdateControl(elapsedTime);
        }

        public virtual void Reset()
        {
            IsTriggered = false;
        }

        public bool IsActive()
        {
            return IsTriggered;
        }
    }

    internal class ControlImplementation<TValue> : ControlImplementation
    {
        private readonly IControlWrapper<TValue> _wrapper;
        private TValue _value;
        public TValue Value => _value;

        public ControlImplementation(IControlWrapper<TValue> wrapper)
            : base(wrapper)
        {
            _wrapper = wrapper;
        }

        public override void Update(float elapsedTime)
        {
            IsTriggered = _wrapper.UpdateControl(elapsedTime, out _value);
        }

        public override void Reset()
        {
            base.Reset();
            _value = default(TValue);
        }

        public bool IsActive(out TValue value)
        {
            value = Value;
            return IsActive();
        }
    }
}