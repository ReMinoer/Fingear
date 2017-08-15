using System.Collections.Generic;
using System.Linq;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlCompositeBase<TControls> : Composite<IControl, IControlParent, TControls>, IControlWrapper
        where TControls : class, IControl
    {
        internal ControlImplementation Implementation;
        public virtual IEnumerable<IInput> Inputs => Components.SelectMany(x => x.Inputs);

        protected ControlCompositeBase()
        {
            Implementation = new ControlImplementation(this);
        }

        internal ControlCompositeBase(ControlImplementation implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper.UpdateControl(float elapsedTime)
        {
            foreach (TControls control in Components)
                control.Update(elapsedTime);

            return UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

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
        public bool IsActive() => Implementation.IsActive();
        public void HandleControl() => Implementation.HandleControl();
        public void HandleInputs() => Implementation.HandleInputs();
    }

    public abstract class ControlCompositeBase<TControls, TValue> : ControlCompositeBase<TControls>, IControlWrapper<TValue>
        where TControls : class, IControl
    {
        new internal ControlImplementation<TValue> Implementation;

        protected ControlCompositeBase()
            : base(null)
        {
            Implementation = new ControlImplementation<TValue>(this);
            base.Implementation = Implementation;
        }

        internal ControlCompositeBase(ControlImplementation<TValue> implementation)
            : base(implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper<TValue>.UpdateControl(float elapsedTime, out TValue value)
        {
            foreach (TControls control in Components)
                control.Update(elapsedTime);

            return UpdateControl(elapsedTime, out value);
        }

        protected override sealed bool UpdateControl(float elapsedTime) => UpdateControl(elapsedTime, out TValue _);
        protected abstract bool UpdateControl(float elapsedTime, out TValue value);

        public bool IsActive(out TValue value) => Implementation.IsActive(out value);
    }
}