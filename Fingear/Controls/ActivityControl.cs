using System;
using System.Collections.Generic;
using Fingear.Controls.Base;

namespace Fingear.Controls
{
    public class ActivityControl : ControlBase<InputActivity>
    {
        private readonly InputActivityMachine _machine = new InputActivityMachine();
        public IInput Input { get; set; }

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public ActivityControl()
        {
        }

        public ActivityControl(IInput input)
        {
            Input = input;
        }

        public ActivityControl(string name, IInput input)
            : this(input)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime, out InputActivity value)
        {
            if (Input == null)
                _machine.Reset();
            else
                _machine.Update(Input.Activity);

            value = _machine.State;
            return value != InputActivity.Idle;
        }

        public override void Reset()
        {
            base.Reset();
            _machine.Reset();
        }
    }
}