using System;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class JoystickToIntensityInput : ForceInputBase<float>, IIntensityInput
    {
        public IJoystickInput JoystickInput { get; set; }
        public Axis Axis { get; set; }
        public override string DisplayName => JoystickInput != null ? $"{JoystickInput.DisplayName} {EnumUtils.GetDisplayName(Axis)}" : "";
        public override IInputSource Source => JoystickInput?.Source;

        public float Maximum
        {
            get
            {
                if (JoystickInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return JoystickInput.Maximum.X;
                    case Axis.Y:
                        return JoystickInput.Maximum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Minimum
        {
            get
            {
                if (JoystickInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return JoystickInput.Minimum.X;
                    case Axis.Y:
                        return JoystickInput.Minimum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public override float Value
        {
            get
            {
                if (JoystickInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return JoystickInput.Value.X;
                    case Axis.Y:
                        return JoystickInput.Value.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public override float IdleValue
        {
            get
            {
                if (JoystickInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return JoystickInput.IdleValue.X;
                    case Axis.Y:
                        return JoystickInput.IdleValue.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Delta
        {
            get
            {
                if (JoystickInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return JoystickInput.Delta.X;
                    case Axis.Y:
                        return JoystickInput.Delta.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public JoystickToIntensityInput()
        {
        }

        public JoystickToIntensityInput(IJoystickInput joystickInput, Axis axis)
        {
            JoystickInput = joystickInput;
            Axis = axis;
        }

        public override void Update()
        {
            JoystickInput.Update();
            base.Update();
        }
    }
}