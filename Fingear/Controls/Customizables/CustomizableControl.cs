using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

namespace Fingear.Controls.Customizables
{
    public class CustomizableControl : CustomizableControl<IInput>
    {
        public CustomizableControl(Func<IInput, IControl> controlFactory, IEnumerable<IInput> defaultInputs = null)
            : base(controlFactory, defaultInputs)
        {
        }

        public CustomizableControl(string name, Func<IInput, IControl> controlFactory, IEnumerable<IInput> defaultInputs = null)
            : base(name, controlFactory, defaultInputs)
        {
        }
    }

    public class CustomizableControl<TInput> : ControlContainerBase<IControl>
        where TInput : IInput
    {
        private Func<TInput, IControl> ControlFactory { get; }
        private readonly Dictionary<TInput, IControl> _dictionary = new Dictionary<TInput, IControl>();
        public ObservableList<TInput> UserInputs { get; } = new ObservableList<TInput>();
        
        public CustomizableControl(Func<TInput, IControl> controlFactory, IEnumerable<TInput> defaultInputs = null)
        {
            ControlFactory = controlFactory;
            UserInputs.CollectionChanged += InputsOnCollectionChanged;

            if (defaultInputs != null)
                UserInputs.AddRange(defaultInputs);
        }

        public CustomizableControl(string name, Func<TInput, IControl> controlFactory, IEnumerable<TInput> defaultInputs = null)
            : this(controlFactory, defaultInputs)
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
                            IControl newControl = ControlFactory(newInput);
                            _dictionary[newInput] = newControl;
                            Components.Add(newControl);
                        }

                    return;
                }
            }
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return Components.Any(x => x.IsActive());
        }
    }
}