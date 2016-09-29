using System;
using Fingear.Converters;
using Fingear.Utils;

namespace Fingear
{
    public class StandardInputConverter : IInputConverter
    {
        public float BooleanDeadZone { get; set; } = 0.5f;

        public T Resolve<T>(IInput input)
            where T : class, IInput
        {
            Type outType = typeof(T);

            if (outType.IsInstanceOfType(input))
                return input as T;

            IInput result = input;

            // First pass : Continous to punctual input

            var cursorInput = input as ICursorInput;
            if (cursorInput != null && typeof(ICursorInput).IsAssignableFrom(outType))
                result = cursorInput.Punctual();
            else
            {
                var scaleInput = input as IScaleInput;
                if (scaleInput != null && typeof(IScaleInput).IsAssignableFrom(outType))
                    result = scaleInput.Punctual();
                else
                {
                    var switchInput = input as ISwitchInput;
                    if (switchInput != null && typeof(ISwitchInput).IsAssignableFrom(outType))
                        result = switchInput.Punctual();
                }
            }
            
            if (outType.IsInstanceOfType(input))
                return input as T;

            // Second pass : Major to minor values

            var joystickInput = result as IJoystickInput;
            if (joystickInput != null)
            {
                if (typeof(IScalarInput).IsAssignableFrom(outType))
                    return joystickInput.Scalar(GetAxis(joystickInput)) as T;
                if (typeof(IBooleanInput).IsAssignableFrom(outType))
                    return joystickInput.Boolean(GetVectorDeadZone(joystickInput)) as T;
            }

            var intensityInput = result as IIntensityInput;
            if (intensityInput != null && typeof(IBooleanInput).IsAssignableFrom(outType))
            {
                return intensityInput.Boolean(GetDeadZone()) as T;
            }

            var cursorInputBis = result as ICursorInput;
            if (cursorInputBis != null)
            {
                if (typeof(IScalarInput).IsAssignableFrom(outType))
                    return cursorInputBis.Scalar(GetAxis(cursorInputBis)) as T;
                if (typeof(IBooleanInput).IsAssignableFrom(outType))
                    return cursorInputBis.Boolean(GetVectorDeadZone(cursorInputBis)) as T;
            }

            var scaleInputBis = result as IScaleInput;
            if (scaleInputBis != null && typeof(IBooleanInput).IsAssignableFrom(outType))
            {
                return scaleInputBis.Boolean(GetDeadZone()) as T;
            }

            throw new NotSupportedException();
        }

        private Axis GetAxis(IVectorInput vectorInput)
        {
            Vector2 delta = vectorInput.Delta;
            return delta.X.Norm() >= delta.Y.Norm() ? Axis.X : Axis.Y;
        }

        private Predicate<Vector2> GetVectorDeadZone(IVectorInput vectorInput)
        {
            Axis axis = GetAxis(vectorInput);
            Vector2 value = vectorInput.Value;

            bool sign = (axis == Axis.X ? value.X : value.Y) >= 0;
            return sign ? DeadZone.Plus(axis, BooleanDeadZone) : DeadZone.Minus(axis, BooleanDeadZone);
        }

        private Predicate<float> GetDeadZone()
        {
            return DeadZone.Radius(BooleanDeadZone);
        }
    }
}