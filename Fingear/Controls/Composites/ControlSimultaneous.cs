using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

namespace Fingear.Controls.Composites
{
    public class ControlSimultaneous<TControls> : ControlCompositeBase<TControls>
        where TControls : class, IControl
    {
        public ControlSimultaneous()
        {
        }

        public ControlSimultaneous(string name)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            if (!Components.All(x => x.IsActive()))
            {
                Sources = Enumerable.Empty<IInputSource>();
                return false;
            }

            Sources = Components.SelectMany(x => x.Sources).ToHashSet(ConservedKey.FirstOccurence).AsReadOnly();
            return true;
        }
    }

    public class ControlSimultaneous<TControls, TValue> : ControlCompositeBase<TControls, TValue>
        where TControls : class, IControl<TValue>
    {
        private readonly Selector<TValue> _valueSelector;

        public ControlSimultaneous()
        {
        }

        public ControlSimultaneous(Selector<TValue> valueSelector)
        {
            _valueSelector = valueSelector;
        }

        public ControlSimultaneous(string name, Selector<TValue> valueSelector)
            : this(valueSelector)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            List<TValue> values = null;

            foreach (TControls component in Components)
            {
                if (!component.IsActive(out TValue componentValue))
                {
                    value = default(TValue);
                    Sources = Enumerable.Empty<IInputSource>();
                    return false;
                }

                if (values == null)
                    values = new List<TValue>();

                values.Add(componentValue);
            }

            if (values == null)
            {
                value = default(TValue);
                Sources = Enumerable.Empty<IInputSource>();
                return false;
            }

            value = _valueSelector != null ? _valueSelector.Invoke(values) : values[0];
            Sources = Components.SelectMany(x => x.Sources).ToHashSet(ConservedKey.FirstOccurence).AsReadOnly();
            return false;
        }
    }
}