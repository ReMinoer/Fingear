using System;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class CursorToScaleInput : PositionInputBase<float>, IScaleInput
    {
        public ICursorInput CursorInput { get; set; }
        public Axis Axis { get; set; }
        public override string DisplayName => CursorInput != null ? $"{CursorInput.DisplayName} {EnumUtils.GetDisplayName(Axis)}" : "";
        public override IInputSource Source => CursorInput?.Source;

        public float Maximum
        {
            get
            {
                if (CursorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return CursorInput.Maximum.X;
                    case Axis.Y:
                        return CursorInput.Maximum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Minimum
        {
            get
            {
                if (CursorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return CursorInput.Minimum.X;
                    case Axis.Y:
                        return CursorInput.Minimum.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public override float Value
        {
            get
            {
                if (CursorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return CursorInput.Value.X;
                    case Axis.Y:
                        return CursorInput.Value.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public float Delta
        {
            get
            {
                if (CursorInput == null)
                    return 0f;

                switch (Axis)
                {
                    case Axis.X:
                        return CursorInput.Delta.X;
                    case Axis.Y:
                        return CursorInput.Delta.Y;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public CursorToScaleInput()
        {
        }

        public CursorToScaleInput(ICursorInput cursorInput, Axis axis)
        {
            CursorInput = cursorInput;
            Axis = axis;
        }

        public override void Update()
        {
            CursorInput.Update();
            base.Update();
        }
    }
}