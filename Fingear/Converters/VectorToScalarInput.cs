using System;
using Fingear.Utils;

namespace Fingear.Converters
{
    public class VectorToScalarInput : IScalarInput
    {
        public IVectorInput VectorInput { get; set; }
        public Axis Axis { get; set; }
        public string DisplayName => VectorInput != null ? $"{VectorInput.DisplayName} {EnumUtils.GetDisplayName(Axis)}" : "";
        public InputActivity Activity => VectorInput?.Activity ?? InputActivity.Idle;
        public IInputSource Source => VectorInput?.Source;

        public float Maximum
        {
            get
            {
                if (VectorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return VectorInput.Maximum.X;
                    case Axis.Y:
                        return VectorInput.Maximum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Minimum
        {
            get
            {
                if (VectorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return VectorInput.Minimum.X;
                    case Axis.Y:
                        return VectorInput.Minimum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Value
        {
            get
            {
                if (VectorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return VectorInput.Value.X;
                    case Axis.Y:
                        return VectorInput.Value.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Delta
        {
            get
            {
                if (VectorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return VectorInput.Delta.X;
                    case Axis.Y:
                        return VectorInput.Delta.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public VectorToScalarInput()
        {
        }

        public VectorToScalarInput(IVectorInput vectorInput, Axis axis)
        {
            VectorInput = vectorInput;
            Axis = axis;
        }
        
        public void Update()
        {
            VectorInput.Update();
        }
    }

    public enum Axis
    {
        X,
        Y
    }
}