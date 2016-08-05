using Fingear.Controls.Base;

namespace Fingear.Controls.Composites
{
    public class ControlSet<TControls> : ControlCompositeBase<TControls>
        where TControls : class, IControl
    {
        public override bool IsTriggered()
        {
            foreach (TControls component in Components)
                if (component.IsTriggered())
                {
                    Source = component.Source;
                    return true;
                }
            
            return false;
        }
    }

    public class ControlSet<TControls, TValue> : ControlCompositeBase<TControls, TValue>
        where TControls : class, IControl<TValue>
    {
        public override bool IsTriggered(out TValue value)
        {
            foreach (TControls component in Components)
                if (component.IsTriggered(out value))
                {
                    Source = component.Source;
                    return true;
                }

            value = default(TValue);
            return false;
        }
    }
}