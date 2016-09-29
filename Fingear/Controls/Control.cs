using System;
using System.Collections.Generic;
using Fingear.Controls.Base;
using Fingear.Utils;

namespace Fingear.Controls
{
    public class Control : ControlBase
    {
        public IInput Input { get; set; }
        public InputActivity DesiredActivity { get; set; }
        public override IEnumerable<IInputSource> Sources => Input?.Source.ToEnumerable();

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public Control()
        {
        }

        public Control(IInput input, InputActivity desiredActivity = InputActivity.Triggered)
        {
            Input = input;
            DesiredActivity = desiredActivity;
        }

        public Control(string name, IInput input, InputActivity desiredActivity = InputActivity.Triggered)
            : this(input, desiredActivity)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return Input?.Activity.Is(DesiredActivity) ?? false;
        }
    }

    public class Control<TValue> : ControlBase<TValue>
    {
        public IInput<TValue> Input { get; set; }
        public Predicate<TValue> ValueFilter { get; set; }
        public override IEnumerable<IInputSource> Sources => Input?.Source.ToEnumerable();

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public Control(IInput<TValue> input)
            : this(input, value => true)
        {
        }

        public Control(string name, IInput<TValue> input)
            : this(name, input, value => true)
        {
        }

        public Control(IInput<TValue> input, Predicate<TValue> valueFilter)
        {
            Input = input;
            ValueFilter = valueFilter;
        }

        public Control(string name, IInput<TValue> input, Predicate<TValue> valueFilter)
            : this(input, valueFilter)
        {
            Name = name;
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