using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : Component<IControl, IControlParent>, IControl
    {
        public abstract IInputSource Source { get; }
        public abstract IEnumerable<IInput> Inputs { get; }

        public virtual void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();
        }

        public abstract bool IsTriggered();
    }

    public abstract class ControlBase<TValue> : ControlBase, IControl<TValue>
    {
        public override sealed bool IsTriggered()
        {
            TValue value;
            return IsTriggered(out value);
        }

        public abstract bool IsTriggered(out TValue value);
    }
}