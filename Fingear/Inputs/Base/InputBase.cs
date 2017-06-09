using System;

namespace Fingear.Inputs.Base
{
    public abstract class InputBase : IInput
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; protected set; }
        public abstract IInputSource Source { get; }
        public bool Updated { get; private set; }
        public IControl Handler { get; internal set; }

        protected InputBase()
        {
            InputManager.Instance.Register(this);
        }

        public void Prepare()
        {
            Updated = false;
        }

        public virtual void Update()
        {
            if (Updated)
                return;

            UpdateValues();
            Updated = true;
        }

        protected abstract void UpdateValues();

        public void HandleBy(IControl handler)
        {
            Handler = handler;
            InputManager.Instance.Handle(this);
        }
    }

    public abstract class InputBase<TValue> : InputBase, IInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private TValue _value;
        public abstract TValue Value { get; }
        protected TValue LastValue { get; private set; }

        protected override void UpdateValues()
        {
            LastValue = _value;
            _value = Value;
            Activity = UpdateActivity(_value);
        }

        protected abstract InputActivity UpdateActivity(TValue value);
    }
}