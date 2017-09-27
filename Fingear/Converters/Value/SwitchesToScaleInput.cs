using System.Collections.Generic;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class SwitchesToScaleInput : PositionInputBase<float>, IScaleInput
    {
        private float _value;
        private float _minimum = 0;
        private float _maximum = 1;

        public ISwitchInput Positive { get; set; }
        public ISwitchInput Negative { get; set; }

        public IEnumerable<ISwitchInput> Switches
        {
            get
            {
                yield return Positive;
                yield return Negative;
            }
        }

        public override string DisplayName => $"{Positive} {Negative}";
        public override IInputSource Source => Positive.Source;
        public float Delta => Maximum - Minimum;

        public override float Value
        {
            get
            {
                if (Positive != null && Positive.Value)
                    _value = Maximum;
                if (Negative != null && Negative.Value)
                    _value = Minimum;
                return _value;
            }
        }


        public float Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                _value = _value.Clamp(_minimum, _maximum);
            }
        }


        public float Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                _value = _value.Clamp(_minimum, _maximum);
            }
        }

        public SwitchesToScaleInput()
        {
        }

        public SwitchesToScaleInput(ISwitchInput positive, ISwitchInput negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public override void Update()
        {
            Positive.Update();
            Negative.Update();
            base.Update();
        }
    }
}