using System;
using System.Collections.Generic;
using Fingear.Inputs.Base;

namespace Fingear.Inputs.Converters.Value
{
    public class ButtonsToIntensityInput : ForceInputBase<float>, IIntensityInput
    {
        public IButtonInput Positive { get; set; }
        public IButtonInput Negative { get; set; }

        protected override IEnumerable<IInput> BaseInputs => Buttons;
        public IEnumerable<IButtonInput> Buttons
        {
            get
            {
                yield return Positive;
                yield return Negative;
            }
        }

        public override string DisplayName => $"{Positive} {Negative}";
        public override IInputSource Source => Positive.Source;

        public override float Value
        {
            get
            {
                float value = IdleValue;
                if (Positive != null && Positive.Value)
                    value += Maximum - IdleValue;
                if (Negative != null && Negative.Value)
                    value += Minimum - IdleValue;
                return value;
            }
        }

        public override float IdleValue => 0;
        public float Maximum { get; set; } = 1;
        public float Minimum { get; set; } = -1;
        public float Delta => Math.Min(Maximum - IdleValue, IdleValue - Minimum);

        public ButtonsToIntensityInput()
        {
        }

        public ButtonsToIntensityInput(IButtonInput positive, IButtonInput negative)
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