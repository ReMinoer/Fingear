using System.Collections.Generic;
using System.Linq;
using Fingear.Controls.Base;

namespace Fingear.Controls.Composites
{
    public class ControlSimultaneous<TControls> : ControlCompositeBase<TControls>
        where TControls : class, IControl
    {
        protected override bool UpdateControl(float elapsedTime)
        {
            if (!Components.All(x => x.IsTriggered()))
                return false;

            Sources = Components.SelectMany(x => x.Sources).Distinct().ToArray();
            return true;
        }
    }

    public class ControlSimultaneous<TControls, TValue> : ControlCompositeBase<TControls, TValue>
        where TControls : class, IControl<TValue>
    {
        private readonly Selector<TValue> _valueSelector;

        public ControlSimultaneous()
        {
            _valueSelector = enumerable => enumerable.FirstOrDefault();
        }

        public ControlSimultaneous(Selector<TValue> valueSelector)
        {
            _valueSelector = valueSelector;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            var valuesList = new List<TValue>();

            foreach (TControls component in Components)
            {
                TValue componentValue;
                if (!component.IsTriggered(out componentValue))
                {
                    value = default(TValue);
                    return false;
                }

                valuesList.Add(componentValue);
            }

            value = _valueSelector(valuesList);
            Sources = Components.SelectMany(x => x.Sources).Distinct().ToArray();
            return false;
        }
    }
}