using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : Component<IControl, IControlParent>, IControlWrapper
    {
        internal ControlImplementation Implementation;
        public abstract IEnumerable<IInputSource> Sources { get; }
        public abstract IEnumerable<IInput> Inputs { get; }

        protected ControlBase()
        {
            Implementation = new ControlImplementation(this);
        }

        internal ControlBase(ControlImplementation implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper.UpdateControl(float elapsedTime) => UpdateControl(elapsedTime);
        protected abstract bool UpdateControl(float elapsedTime);

        public string Name
        {
            get => Implementation.Name;
            set => Implementation.Name = value;
        }
        public bool Handled => Implementation.Handled;
        public void Update(float elapsedTime) => Implementation.Update(elapsedTime);
        public bool IsActive() => Implementation.IsActive();
        public void HandleControl() => Implementation.HandleControl();
        public void HandleInputs() => Implementation.HandleInputs();
    }

    public abstract class ControlBase<TValue> : ControlBase, IControlWrapper<TValue>
    {
        new internal ControlImplementation<TValue> Implementation;

        protected ControlBase()
            : base(null)
        {
            Implementation = new ControlImplementation<TValue>(this);
            base.Implementation = Implementation;
        }

        internal ControlBase(ControlImplementation<TValue> implementation)
            : base(implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper<TValue>.UpdateControl(float elapsedTime, out TValue value) => UpdateControl(elapsedTime, out value);
        protected override sealed bool UpdateControl(float elapsedTime) => UpdateControl(elapsedTime, out TValue _);
        protected abstract bool UpdateControl(float elapsedTime, out TValue value);

        public bool IsActive(out TValue value) => Implementation.IsActive(out value);
    }
}