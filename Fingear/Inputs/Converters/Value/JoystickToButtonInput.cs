using System;
using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Inputs.Converters.Value
{
    public class JoystickToButtonInput : ForceInputBase<bool>, IButtonInput
    {
        public IJoystickInput JoystickInput { get; set; }
        public Predicate<Vector2> ValueSelector { get; set; }

        public override IInputSource Source => JoystickInput?.Source;
        public override bool Value => JoystickInput != null && ValueSelector(JoystickInput.Value);
        public override bool IdleValue => JoystickInput != null && ValueSelector(JoystickInput.IdleValue);

        protected override IEnumerable<IInput> BaseInputs
        {
            get { yield return JoystickInput; }
        }

        public override string DisplayName
        {
            get
            {
                if (JoystickInput == null)
                    return "";

                string name = ValueSelector.Method.GetDelegateName();
                return string.IsNullOrEmpty(name) ? $"{JoystickInput.DisplayName}" : $"{JoystickInput.DisplayName} {name}";
            }
        }

        public JoystickToButtonInput()
        {
        }

        public JoystickToButtonInput(IJoystickInput joystickInput, Predicate<Vector2> valueSelector)
        {
            JoystickInput = joystickInput;
            ValueSelector = valueSelector;
        }

        public override void Update()
        {
            JoystickInput.Update();
            base.Update();
        }
    }
}