using System;
using System.Collections.Generic;
using Fingear.Controls.Base;

namespace Fingear.Controls
{
    public class ValueControl<TValue> : ControlBase<TValue>
    {
        public IInput<TValue> Input { get; set; }
        public Predicate<TValue> ValueFilter { get; set; }
        public override IEnumerable<IInputSource> Sources => Input?.Source.ToEnumerable();

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public ValueControl(IInput<TValue> input, Predicate<TValue> valueFilter)
        {
            Input = input;
            ValueFilter = valueFilter;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            if (Input != null && ValueFilter(Input.Value))
            {
                value = Input.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }
    }
}