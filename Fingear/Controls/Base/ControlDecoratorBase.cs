using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlDecoratorBase<TControl> : Decorator<IControl, IControlParent, TControl>, IControlDecorator<TControl>
        where TControl : class, IControl
    {
        public IInputSource Source { get; protected set; }
        public virtual IEnumerable<IInput> Inputs => Component.Inputs;

        public virtual void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            Component.Update(elapsedTime);
        }

        public abstract bool IsTriggered();
    }

    public abstract class ControlDecoratorBase<TControl, TValue> : ControlDecoratorBase<TControl>, IControlDecorator<TControl, TValue>
        where TControl : class, IControl
    {
        public override sealed bool IsTriggered()
        {
            TValue value;
            return IsTriggered(out value);
        }

        public abstract bool IsTriggered(out TValue value);
    }
}