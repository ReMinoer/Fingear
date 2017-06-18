using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlDecoratorBase<TControl> : Decorator<IControl, IControlParent, TControl>, IControlWrapper
        where TControl : class, IControl
    {
        internal ControlImplementation Implementation;
        public IEnumerable<IInputSource> Sources => Component.Sources;
        public virtual IEnumerable<IInput> Inputs => Component.Inputs;

        protected ControlDecoratorBase()
        {
            Implementation = new ControlImplementation(this);
        }

        internal ControlDecoratorBase(ControlImplementation implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper.UpdateControl(float elapsedTime)
        {
            Component.Update(elapsedTime);
            return UpdateControl(elapsedTime);
        }

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

    public abstract class ControlDecoratorBase<TControl, TValue> : ControlDecoratorBase<TControl>, IControlWrapper<TValue>
        where TControl : class, IControl
    {
        new internal ControlImplementation<TValue> Implementation;

        protected ControlDecoratorBase()
            : base(null)
        {
            Implementation = new ControlImplementation<TValue>(this);
            base.Implementation = Implementation;
        }

        internal ControlDecoratorBase(ControlImplementation<TValue> implementation)
            : base(implementation)
        {
            Implementation = implementation;
        }

        bool IControlWrapper<TValue>.UpdateControl(float elapsedTime, out TValue value)
        {
            Component.Update(elapsedTime);
            return UpdateControl(elapsedTime, out value);
        }

        protected override sealed bool UpdateControl(float elapsedTime) => UpdateControl(elapsedTime, out TValue _);
        protected abstract bool UpdateControl(float elapsedTime, out TValue value);

        public bool IsActive(out TValue value) => Implementation.IsActive(out value);
    }
}