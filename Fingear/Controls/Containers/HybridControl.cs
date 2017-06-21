using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Fingear.Controls.Base;

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

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            bool valueActive = ValueControl.IsActive(out value);

            if (TriggerControl.IsActive())
            {
                IEnumerable<IInputSource> sources = TriggerControl.Sources;

                if (valueActive)
                    sources = sources.Concat(ValueControl.Sources);

                Sources = sources.ToArray().AsReadOnly();
                return true;
            }

            Sources = Enumerable.Empty<IInputSource>();
            return false;
        }
    }
}