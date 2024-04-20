using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Diese.Collections;
using Diese.Collections.Observables;
using Fingear.Controls.Base;
using Fingear.Inputs;
using Fingear.Utils;

namespace Fingear.Controls.Customizables
{
    public class CustomizableControlValue<TValue> : CustomizableControlValue<IInput<TValue>, TValue>
    {
        public CustomizableControlValue(Func<IInput<TValue>, IControl<TValue>> controlFactory, IEnumerable<IInput<TValue>> defaultInputs = null)
            : base(controlFactory, defaultInputs)
        {
        }

        public CustomizableControlValue(string name, Func<IInput<TValue>, IControl<TValue>> controlFactory, IEnumerable<IInput<TValue>> defaultInputs = null)
            : base(name, controlFactory, defaultInputs)
        {
        }

        public CustomizableControlValue(Func<IInput<TValue>, IControl<TValue>> controlFactory, Selector<TValue> valueSelector, IEnumerable<IInput<TValue>> defaultInputs = null)
            : base(controlFactory, valueSelector, defaultInputs)
        {
        }

        public CustomizableControlValue(string name, Func<IInput<TValue>, IControl<TValue>> controlFactory, Selector<TValue> valueSelector, IEnumerable<IInput<TValue>> defaultInputs = null)
            : base(name, controlFactory, valueSelector, defaultInputs)
        {
        }
    }

    public class CustomizableControlValue<TInput, TValue> : ControlContainerBase<IControl<TValue>, TValue>
        where TInput : IInput
    {
        private readonly Selector<TValue> _valueSelector;
        private Func<TInput, IControl<TValue>> ControlFactory { get; }
        private readonly Dictionary<TInput, IControl<TValue>> _dictionary = new Dictionary<TInput, IControl<TValue>>();
        public ObservableList<TInput> UserInputs { get; } = new ObservableList<TInput>();

        public CustomizableControlValue(Func<TInput, IControl<TValue>> controlFactory, IEnumerable<TInput> defaultInputs = null)
        {
            ControlFactory = controlFactory;
            UserInputs.CollectionChanged += InputsOnCollectionChanged;

            if (defaultInputs != null)
                UserInputs.AddMany(defaultInputs);
        }

        public CustomizableControlValue(string name, Func<TInput, IControl<TValue>> controlFactory, IEnumerable<TInput> defaultInputs = null)
            : this(controlFactory, defaultInputs)
        {
            Name = name;
        }

        public CustomizableControlValue(Func<TInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector, IEnumerable<TInput> defaultInputs = null)
            : this(controlFactory, defaultInputs)
        {
            _valueSelector = valueSelector;
        }

        public CustomizableControlValue(string name, Func<TInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector, IEnumerable<TInput> defaultInputs = null)
            : this(controlFactory, valueSelector, defaultInputs)
        {
            Name = name;
        }

        private void InputsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                {
                    Components.Clear();
                    _dictionary.Clear();
                    return;
                }
                default:
                {
                    if (eventArgs.OldItems != null)
                        foreach (TInput oldInput in eventArgs.OldItems.Cast<TInput>())
                        {
                            Components.Remove(_dictionary[oldInput]);
                            _dictionary.Remove(oldInput);
                        }

                    if (eventArgs.NewItems != null)
                        foreach (TInput newInput in eventArgs.NewItems.Cast<TInput>())
                        {
                            IControl<TValue> newControl = ControlFactory(newInput);
                            _dictionary[newInput] = newControl;
                            Components.Add(newControl);
                        }

                    return;
                }
            }
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