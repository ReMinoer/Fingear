using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

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
            HashSet<IInputSource> sources = null;
            foreach (IControl component in Components.Where(x => x.IsActive()))
            {
                if (sources == null)
                    sources = new HashSet<IInputSource>();

                foreach (IInputSource source in component.Sources)
                    sources.Add(source);
            }

            if (sources == null)
            {
                Sources = Enumerable.Empty<IInputSource>();
                return false;
            }

            Sources = sources.AsReadOnly();
            return sources.Count > 0;
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

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            List<TValue> values = null;
            HashSet<IInputSource> sources = null;

            foreach (IControl<TValue> component in Components)
            {
                if (!component.IsActive(out TValue componentValue))
                    continue;

                if (values == null)
                {
                    values = new List<TValue>();
                    sources = new HashSet<IInputSource>();
                }

                values.Add(componentValue);
                foreach (IInputSource source in component.Sources)
                    sources.Add(source);
            }

            if (values == null)
            {
                value = default(TValue);
                Sources = Enumerable.Empty<IInputSource>();
                return false;
            }

            value = _valueSelector != null ? _valueSelector(values) : values[0];
            Sources = sources.AsReadOnly();
            return sources.Count > 0;
        }
    }
}