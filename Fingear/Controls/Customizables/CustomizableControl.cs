using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

namespace Fingear.Controls.Customizables
{
    public class CustomizableControl : CustomizableControl<IInput>
    {
        public CustomizableControl(Func<IInput, IControl> controlFactory)
            : base(controlFactory)
        {
        }

        public CustomizableControl(string name, Func<IInput, IControl> controlFactory)
            : base(name, controlFactory)
        {
        }
    }

    public class CustomizableControlValue<TValue> : CustomizableControlValue<IInput, TValue>
    {
        public CustomizableControlValue(Func<IInput, IControl<TValue>> controlFactory)
            : base(controlFactory)
        {
        }

        public CustomizableControlValue(string name, Func<IInput, IControl<TValue>> controlFactory)
            : base(name, controlFactory)
        {
        }

        public CustomizableControlValue(Func<IInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector)
            : base(controlFactory, valueSelector)
        {
        }

        public CustomizableControlValue(string name, Func<IInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector)
            : base(name, controlFactory, valueSelector)
        {
        }
    }

    public class CustomizableControl<TInput> : ControlContainerBase<IControl>
        where TInput : IInput
    {
        private Func<TInput, IControl> ControlFactory { get; }
        private readonly Dictionary<TInput, IControl> _dictionary = new Dictionary<TInput, IControl>();
        public ObservableCollection<TInput> UserInputs { get; } = new ObservableCollection<TInput>();
        
        public CustomizableControl(Func<TInput, IControl> controlFactory)
        {
            ControlFactory = controlFactory;
            UserInputs.CollectionChanged += InputsOnCollectionChanged;
        }

        public CustomizableControl(string name, Func<TInput, IControl> controlFactory)
            : this(controlFactory)
        {
            Name = name;
        }

        private void InputsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
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
                    IControl newControl = ControlFactory(newInput);
                    _dictionary[newInput] = newControl;
                    Components.Add(newControl);
                }
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return Components.Any(x => x.IsActive());
        }
    }

    public class CustomizableControlValue<TInput, TValue> : ControlContainerBase<IControl<TValue>, TValue>
        where TInput : IInput
    {
        private readonly Selector<TValue> _valueSelector;
        private Func<TInput, IControl<TValue>> ControlFactory { get; }
        private readonly Dictionary<TInput, IControl<TValue>> _dictionary = new Dictionary<TInput, IControl<TValue>>();
        public ObservableCollection<TInput> UserInputs { get; } = new ObservableCollection<TInput>();

        public CustomizableControlValue(Func<TInput, IControl<TValue>> controlFactory)
        {
            ControlFactory = controlFactory;
            UserInputs.CollectionChanged += InputsOnCollectionChanged;
        }

        public CustomizableControlValue(string name, Func<TInput, IControl<TValue>> controlFactory)
            : this(controlFactory)
        {
            Name = name;
        }

        public CustomizableControlValue(Func<TInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector)
            : this(controlFactory)
        {
            _valueSelector = valueSelector;
        }

        public CustomizableControlValue(string name, Func<TInput, IControl<TValue>> controlFactory, Selector<TValue> valueSelector)
            : this(controlFactory, valueSelector)
        {
            Name = name;
        }

        private void InputsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
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
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
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