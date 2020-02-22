using System.Collections.Generic;
using System.Linq;
using Fingear.Controls.Base;
using Fingear.Utils;

namespace Fingear.Controls.Composites
{
    public class ControlSet : ControlCompositeBase<IControl>
    {
        public ControlSet()
        {
        }

        public ControlSet(string name)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return Components.Any(x => x.IsActive);
        }
    }

    public class ControlSet<TValue> : ControlCompositeBase<IControl<TValue>, TValue>
    {
        private readonly Selector<TValue> _valueSelector;

        public ControlSet()
        {
        }

        public ControlSet(string name)
            : this()
        {
            Name = name;
        }

        public ControlSet(Selector<TValue> valueSelector)
        {
            _valueSelector = valueSelector;
        }

        public ControlSet(string name, Selector<TValue> valueSelector)
            : this(valueSelector)
        {
            Name = name;
        }

        protected override bool UpdateControlValue(float elapsedTime, out TValue value)
        {
            List<TValue> values = null;
            foreach (IControl<TValue> component in Components)
            {
                if (!component.IsActive(out TValue componentValue))
                    continue;

                if (values == null)
                    values = new List<TValue>();

                values.Add(componentValue);
            }

            if (values == null)
            {
                value = default(TValue);
                return false;
            }

            value = _valueSelector != null ? _valueSelector(values) : values[0];
            return true;
        }
    }
}