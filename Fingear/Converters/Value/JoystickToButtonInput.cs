using System;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class JoystickToButtonInput : PonctualInputBase<bool>, IButtonInput
    {
        public IJoystickInput JoystickInput { get; set; }
        public Predicate<Vector2> ValueSelector { get; set; }
        public override IInputSource Source => JoystickInput?.Source;
        public override bool Value => JoystickInput != null && ValueSelector(JoystickInput.Value);
        public override bool IdleValue => JoystickInput != null && ValueSelector(JoystickInput.IdleValue);

        public override string DisplayName
        {
            get
            {
                if (JoystickInput == null)
                    return "";

                string name = ValueSelector.Method.GetDelegateName();
                if (string.IsNullOrEmpty(name))
                    return $"{JoystickInput.DisplayName}";

                return $"{JoystickInput.DisplayName} {name}";
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