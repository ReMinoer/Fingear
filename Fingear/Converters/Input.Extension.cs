using System;
using Fingear.Converters.Activity;
using Fingear.Converters.Value;

namespace Fingear.Converters
{
    static public class InputExtension
    {
        static public IJoystickInput Punctual(this ICursorInput input)
        {
            return new CursorToJoystickInput(input);
        }

        static public IIntensityInput Punctual(this IScaleInput input)
        {
            return new ScaleToIntensityInput(input);
        }

        static public IButtonInput Punctual(this ISwitchInput input)
        {
            return new SwitchToButtonInput(input);
        }

        static public IIntensityInput Scalar(this IJoystickInput input, Axis axis)
        {
            return new JoystickToIntensityInput(input, axis);
        }

        static public IScaleInput Scalar(this ICursorInput input, Axis axis)
        {
            return new CursorToScaleInput(input, axis);
        }

        static public IButtonInput Boolean(this IJoystickInput input, Predicate<Vector2> valueSelector)
        {
            return new JoystickToButtonInput(input, valueSelector);
        }

        static public IButtonInput Boolean(this IIntensityInput input, Predicate<float> valueValidator)
        {
            return new IntensityToButtonInput(input, valueValidator);
        }

        static public ISwitchInput Boolean(this ICursorInput input, Predicate<Vector2> valueSelector)
        {
            return new CursorToSwitchInput(input, valueSelector);
        }

        static public ISwitchInput Boolean(this IScaleInput input, Predicate<float> valueValidator)
        {
            return new ScaleToSwitchInput(input, valueValidator);
        }
    }
}