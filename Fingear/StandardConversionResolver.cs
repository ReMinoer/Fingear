using System;
using Fingear.Converters;

namespace Fingear
{
    public class StandardConversionResolver : IConversionResolver
    {
        public float DeadZoneForBoolean { get; set; } = 0.1f;

        public T Resolve<T>(IInput input)
            where T : class, IInput
        {
            Type outType = typeof(T);

            if (outType.IsInstanceOfType(input))
                return input as T;

            var vectorInput = input as IVectorInput;
            if (vectorInput != null && typeof(IScalarInput).IsAssignableFrom(outType) && outType.IsAssignableFrom(typeof(VectorToScalarInput)))
            {
                Axis axis = Math.Abs(vectorInput.Delta.X) > Math.Abs(vectorInput.Delta.Y) ? Axis.X : Axis.Y;
                return new VectorToScalarInput(vectorInput, axis) as T;
            }

            var scalarInput = input as IScalarInput;
            if (scalarInput != null && typeof(IBooleanInput).IsAssignableFrom(outType) && outType.IsAssignableFrom(typeof(ScalarToBooleanInput)))
                return new ScalarToBooleanInput(scalarInput, DeadZoneForBoolean) as T;

            throw new NotSupportedException();
        }
    }
}