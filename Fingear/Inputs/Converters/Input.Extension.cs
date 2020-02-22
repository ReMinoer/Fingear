using System;
using System.Numerics;
using Fingear.Inputs.Converters.Activity;
using Fingear.Inputs.Converters.Value;

namespace Fingear.Inputs.Converters
{
    static public class InputExtension
    {
        static public IJoystickInput Force(this ICursorInput input)
        {
            return new CursorToJoystickInput(input);
        }

        static public IIntensityInput Force(this IScaleInput input)
        {
            return new ScaleToIntensityInput(input);
        }

        static public IButtonInput Force(this ISwitchInput input)
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

        static public IIntensityInput Scalar(this (IButtonInput x, IButtonInput y) inputs, float min, float max)
        {
            return new ButtonsToIntensityInput(inputs.x, inputs.y)
            {
                Minimum = min,
                Maximum = max
            };
        }

        static public IScaleInput Scalar(this (ISwitchInput x, ISwitchInput y) inputs, float min, float max)
        {
            return new SwitchesToScaleInput(inputs.x, inputs.y)
            {
                Minimum = min,
                Maximum = max
            };
        }

        static public IJoystickInput Vector(this (IIntensityInput x, IIntensityInput y) inputs, Vector2 min, Vector2 max)
        {
            return new IntensitiesToJoystickInput(inputs.x, inputs.y)
            {
                Minimum = min,
                Maximum = max
            };
        }

        static public ICursorInput Vector(this (IScaleInput x, IScaleInput y) inputs, Vector2 min, Vector2 max)
        {
            return new ScalesToCursorInput(inputs.x, inputs.y)
            {
                Minimum = min,
                Maximum = max
            };
        }

        static public IJoystickInput Vector(this (IButtonInput left, IButtonInput right, IButtonInput up, IButtonInput down) inputs, Vector2 min, Vector2 max)
        {
            return new ButtonsToJoystickInput(inputs.left, inputs.right, inputs.up, inputs.down)
            {
                Minimum = min,
                Maximum = max
            };
        }

        static public ICursorInput Vector(this (ISwitchInput left, ISwitchInput right, ISwitchInput up, ISwitchInput down) inputs, Vector2 min, Vector2 max)
        {
            return new SwitchesToCursorInput(inputs.left, inputs.right, inputs.up, inputs.down)
            {
                Minimum = min,
                Maximum = max
            };
        }
    }
}