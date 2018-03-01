using System.Collections.Generic;
using Fingear.Controls.Base;

namespace Fingear.Controls
{
    public class Control : ControlBase
    {
        private readonly InputActivityMachine _machine = new InputActivityMachine();
        public IInput Input { get; set; }
        public InputActivity DesiredActivity { get; set; }

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
            if (Input == null)
                _machine.Reset();
            else
                _machine.Update(Input.Activity);

            return _machine.State.Is(DesiredActivity);
        }

        public override void Reset()
        {
            base.Reset();
            _machine.Reset();
        }
    }

    public class Control<TValue> : ControlBase<TValue>
    {
        public IInput<TValue> Input { get; set; }

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public Control()
        {
        }

        public Control(IInput<TValue> input)
        {
            Input = input;
        }

        public Control(string name, IInput<TValue> input)
            : this(input)
        {
            Name = name;
        }

        protected override sealed bool UpdateControl(float elapsedTime, out TValue value)
        {
            if (Input == null || Input.Activity == InputActivity.Idle)
            {
                value = default(TValue);
                return false;
            }

            value = GetValue();
            return true;
        }

        protected virtual TValue GetValue() => Input.Value;
    }
}