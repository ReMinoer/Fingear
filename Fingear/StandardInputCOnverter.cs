using System;
using System.Numerics;
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
            if (TryResolve(input, out T result))
                return result;
            throw new NotSupportedException();
        }

        public bool TryResolve<T>(IInput input, out T result)
            where T : class, IInput
        {
            result = input as T;
            if (result != null)
                return true;

            Type outType = typeof(T);

            // First pass : Position to force input

            bool isForceInput = input is IForceInput;
            if (!isForceInput && typeof(IForceInput).IsAssignableFrom(outType))
            {
                switch (input)
                {
                    case ICursorInput cursorInput:
                        input = cursorInput.Force();
                    break;
                    case IScaleInput scaleInput:
                        input = scaleInput.Force();
                    break;
                    case ISwitchInput switchInput:
                        input = switchInput.Force();
                    break;
                }
                
                result = input as T;
                if (result != null)
                    return true;

                isForceInput = true;
            }

            // Second pass : More to less values

            if (isForceInput)
            {
                switch (input)
                {
                    case IJoystickInput joystickInput:
                    {
                        if (typeof(IScalarInput).IsAssignableFrom(outType))
                        {
                            result = joystickInput.Scalar(GetAxis(joystickInput)) as T;
                            return true;
                        }

                        if (typeof(IBooleanInput).IsAssignableFrom(outType))
                        {
                            result = joystickInput.Boolean(GetVectorDeadZone(joystickInput)) as T;
                            return true;
                        }
                    }
                    break;
                    case IIntensityInput intensityInput:
                    {
                        if (typeof(IBooleanInput).IsAssignableFrom(outType))
                        {
                            result = intensityInput.Boolean(GetDeadZone()) as T;
                            return true;
                        }
                    }
                    break;
                }
            }
            else if (input is IPositionInput)
            {
                switch (input)
                {
                    case ICursorInput cursorInputBis:
                    {
                        if (typeof(IScalarInput).IsAssignableFrom(outType))
                        {
                            result = cursorInputBis.Scalar(GetAxis(cursorInputBis)) as T;
                            return true;
                        }

                        if (typeof(IBooleanInput).IsAssignableFrom(outType))
                        {
                            result = cursorInputBis.Boolean(GetVectorDeadZone(cursorInputBis)) as T;
                            return true;
                        }
                    }
                    break;
                    case IScaleInput scaleInputBis:
                    {
                        if (typeof(IBooleanInput).IsAssignableFrom(outType))
                        {
                            result = scaleInputBis.Boolean(GetDeadZone()) as T;
                            return true;
                        }
                    }
                    break;
                }
            }

            return false;
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