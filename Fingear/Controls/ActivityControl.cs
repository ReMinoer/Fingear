using System.Collections.Generic;
using Fingear.Controls.Base;
using Fingear.Utils;

namespace Fingear.Controls
{
    public class ActivityControl : ControlBase<InputActivity>
    {
        public IInput Input { get; set; }
        public override IEnumerable<IInputSource> Sources => Input?.Source.ToEnumerable();

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
            value = Input?.Activity ?? InputActivity.Idle;
            return value != InputActivity.Idle;
        }
    }
}