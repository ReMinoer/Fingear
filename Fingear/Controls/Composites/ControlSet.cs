using System.Collections.Generic;
using System.Linq;
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
            Sources = Components.Where(x => x.IsActive()).SelectMany(x => x.Sources).Distinct().ToArray();
            return Sources.Any();
        }
    }

    public class ControlSet<TValue> : ControlCompositeBase<IControl<TValue>, TValue>
    {
        private readonly Selector<TValue> _valueSelector;

        public ControlSet()
        {
            _valueSelector = enumerable => enumerable.FirstOrDefault();
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
            var valuesList = new List<TValue>();
            var sourcesList = new List<IInputSource>();

            foreach (IControl<TValue> component in Components)
            {
                TValue componentValue;
                if (!component.IsActive(out componentValue))
                    continue;

                valuesList.Add(componentValue);
                sourcesList.AddRange(component.Sources);
            }

            value = _valueSelector(valuesList);
            Sources = sourcesList.Distinct().ToList();
            return sourcesList.Count > 0;
        }
    }
}