using System;
using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class SwitchesToCursorInput : PositionInputBase<Vector2>, ICursorInput
    {
        private Vector2 _value;
        private Vector2 _minimum = Vector2.Zero;
        private Vector2 _maximum = Vector2.One;

        public ISwitchInput Left { get; set; }
        public ISwitchInput Right { get; set; }
        public ISwitchInput Up { get; set; }
        public ISwitchInput Down { get; set; }
        
        protected override IEnumerable<IInput> BaseInputs => Switches;
        public IEnumerable<ISwitchInput> Switches
        {
            get
            {
                yield return Left;
                yield return Right;
                yield return Up;
                yield return Down;
            }
        }

        public override string DisplayName => $"{Left} {Right} {Up} {Down}";
        public override IInputSource Source => Left.Source;
        public Vector2 Delta => Maximum - Minimum;

        public override Vector2 Value
        {
            get
            {
                if (Left != null && Left.Value)
                    _value.X = Minimum.X;
                if (Right != null && Right.Value)
                    _value.X = Maximum.X;
                if (Up != null && Up.Value)
                    _value.Y = Maximum.Y;
                if (Down != null && Down.Value)
                    _value.Y = Minimum.Y;
                return _value;
            }
        }


        public Vector2 Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                _value = _value.Clamp(_minimum, _maximum);
            }
        }


        public Vector2 Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                _value = _value.Clamp(_minimum, _maximum);
            }
        }

        public SwitchesToCursorInput()
        {
        }

        public SwitchesToCursorInput(ISwitchInput left, ISwitchInput right, ISwitchInput up, ISwitchInput down)
        {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }

        public override void Update()
        {
            Left.Update();
            Right.Update();
            Up.Update();
            Down.Update();
            base.Update();
        }
    }
}