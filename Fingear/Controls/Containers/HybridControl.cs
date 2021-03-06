﻿using Fingear.Controls.Base;

namespace Fingear.Controls.Containers
{
    public class HybridControl<TValue> : ControlContainerBase<IControl, TValue>
    {
        private IControl _triggerControl;
        private IControl<TValue> _valueControl;

        public IControl TriggerControl
        {
            get => _triggerControl;
            set
            {
                if (_triggerControl == value)
                    return;

                if (_triggerControl != null)
                    Components.Remove(_triggerControl);

                _triggerControl = value;

                if (_triggerControl != null)
                    Components.Add(_triggerControl);
            }
        }

        public IControl<TValue> ValueControl
        {
            get => _valueControl;
            set
            {
                if (_valueControl == value)
                    return;

                if (_valueControl != null)
                    Components.Remove(_valueControl);

                _valueControl = value;

                if (_valueControl != null)
                    Components.Add(_valueControl);
            }
        }

        public HybridControl()
        {
        }

        public HybridControl(string name)
            : this()
        {
            Name = name;
        }

        public HybridControl(IControl triggerControl, IControl<TValue> valueControl)
            : this()
        {
            TriggerControl = triggerControl;
            ValueControl = valueControl;
        }

        public HybridControl(string name, IControl triggerControl, IControl<TValue> valueControl)
            : this(triggerControl, valueControl)
        {
            Name = name;
        }

        protected override bool UpdateControlValue(float elapsedTime, out TValue value)
        {
            ValueControl.IsActive(out value);
            return TriggerControl.IsActive;
        }
    }
}