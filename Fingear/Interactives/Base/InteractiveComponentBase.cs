using Fingear.Controls;
using Stave;

namespace Fingear.Interactives.Base
{
    public abstract class InteractiveComponentBase : InteractiveBase
    {
        protected override IComponent<IInteractive, IInteractiveContainer> ComponentImplementation { get; }

        protected InteractiveComponentBase()
        {
            ComponentImplementation = new Component<IInteractive, IInteractiveContainer>(this);
        }

        protected override void UpdateEnabled(float elapsedTime)
        {
            foreach (IControl control in ReadOnlyControls)
                control.Update(elapsedTime);
        }

        public override void Reset()
        {
            foreach (IControl control in ReadOnlyControls)
                control.Reset();
        }
    }
}