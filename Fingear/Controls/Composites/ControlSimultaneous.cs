using System.Collections.Generic;
using System.Linq;
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
            if (!ReadOnlyComponents.All(x => x.IsActive()))
                return false;

            Sources = ReadOnlyComponents.SelectMany(x => x.Sources).Distinct().ToArray();
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

        public ControlSimultaneous(string name, Selector<TValue> valueSelector)
            : this(valueSelector)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            var valuesList = new List<TValue>();

            foreach (TControls component in ReadOnlyComponents)
            {
                TValue componentValue;
                if (!component.IsActive(out componentValue))
                {
                    value = default(TValue);
                    return false;
                }

                valuesList.Add(componentValue);
            }

            value = _valueSelector(valuesList);
            Sources = ReadOnlyComponents.SelectMany(x => x.Sources).Distinct().ToArray();
            return false;
        }
    }
}