using System.Collections.Generic;
using Fingear.Controls.Base;

namespace Fingear.Controls
{
    public class ActivityControl : ControlBase
    {
        public IInput Input { get; set; }
        public InputActivity DesiredActivity { get; set; }
        public override IEnumerable<IInputSource> Sources => Input?.Source.ToEnumerable();

        public override IEnumerable<IInput> Inputs
        {
            get { yield return Input; }
        }

        public ActivityControl(IInput input, InputActivity desiredActivity = InputActivity.Triggered)
        {
            Input = input;
            DesiredActivity = desiredActivity;
        }

        protected override bool UpdateControl(float elapsedTime)
        {
            return Input?.Activity.Is(DesiredActivity) ?? false;
        }
    }
}