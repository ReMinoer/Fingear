using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : Component<IControl, IControlContainer>, IControlWrapper
    {
        protected ControlImplementation Implementation;
        public abstract IEnumerable<IInput> Inputs { get; }

        protected ControlBase()
        {
            Implementation = new ControlImplementation(this);
        }

        internal ControlBase(ControlImplementation implementation)
        {
            Implementation = implementation;
        }

        public string Name
        {
            get => Implementation.Name;
            set => Implementation.Name = value;
        }

        public ControlLayer Layer
        {
            get => Implementation.Layer;
            set => Implementation.Layer = value;
        }

        public bool Handled => Implementation.Handled;
        public void Update(float elapsedTime) => Implementation.Update(elapsedTime);
        public virtual void Reset() => Implementation.Reset();
        public bool IsActive() => Implementation.IsActive();
        public void HandleControl() => Implementation.HandleControl();
        public void HandleInputs() => Implementation.HandleInputs();

        bool IControlWrapper.UpdateControl(float elapsedTime) => UpdateControl(elapsedTime);
        protected abstract bool UpdateControl(float elapsedTime);
    }

    public abstract class ControlBase<TValue> : ControlBase, IControlWrapper<TValue>
    {
        new internal readonly ControlImplementation<TValue> Implementation;

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