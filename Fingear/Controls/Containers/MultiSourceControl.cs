using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

namespace Fingear.Controls.Containers
{
    public class MultiSourceControl : ControlContainerBase<IControl>
    {
        private readonly Dictionary<InputSourceType, IControl> _typeControlSets = new Dictionary<InputSourceType, IControl>();
        public InputSourceTypes Types { get; set; } = InputSourceTypes.All;

        public IControl this[InputSourceType type]
        {
            get => _typeControlSets[type];
            set
            {
                if (_typeControlSets.TryGetValue(type, out IControl control))
                    Components.Replace(control, value);
                else
                    Components.Add(value);

                _typeControlSets[type] = value;
            }
        }
        public MultiSourceControl()
        {
        }

        public MultiSourceControl(string name)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return _typeControlSets.Where(x => Types.Match(x.Key)).Any(x => x.Value.IsActive);
        }
    }

    public class MultiSourceControl<TValue> : ControlContainerBase<IControl<TValue>, TValue>
    {
        private readonly Dictionary<InputSourceType, IControl<TValue>> _typeControlSets = new Dictionary<InputSourceType, IControl<TValue>>();
        private readonly Selector<TValue> _valueSelector;
        public InputSourceTypes Types { get; } = InputSourceTypes.All;

        public IControl<TValue> this[InputSourceType type]
        {
            get => _typeControlSets[type];
            set
            {
                if (_typeControlSets.TryGetValue(type, out IControl<TValue> control))
                    Components.Replace(control, value);
                else
                    Components.Add(value);

                _typeControlSets[type] = value;
            }
        }

        public MultiSourceControl()
        {
        }

        public MultiSourceControl(string name)
            : this()
        {
            Name = name;
        }

        public MultiSourceControl(Selector<TValue> valueSelector)
        {
            _valueSelector = valueSelector;
        }

        public MultiSourceControl(string name, Selector<TValue> valueSelector)
            : this(valueSelector)
        {
            Name = name;
        }

        protected override bool UpdateControlValue(float elapsedTime, out TValue value)
        {
            List<TValue> values = null;
            foreach (IControl<TValue> component in _typeControlSets.Where(x => Types.Match(x.Key)).Select(x => x.Value))
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