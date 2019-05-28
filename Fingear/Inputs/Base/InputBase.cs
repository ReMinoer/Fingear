using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fingear.Inputs.Base
{
    public abstract class InputBase : IInput, INotifyPropertyChanged
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; protected set; }
        public abstract IInputSource Source { get; }
        public bool Updated { get; private set; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class InputBase<TValue> : InputBase, IInput<TValue>
        where TValue : IEquatable<TValue>
    {
        protected TValue CurrentValue;
        public abstract TValue Value { get; }
        protected TValue LastValue { get; set; }

        protected override void UpdateValues()
        {
            LastValue = CurrentValue;
            CurrentValue = Value;
            Activity = UpdateActivity(CurrentValue);
        }

        protected abstract InputActivity UpdateActivity(TValue value);
    }
}