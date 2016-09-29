﻿using System;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class IntensityToButtonInput : PonctualInputBase<bool>, IButtonInput
    {
        public IIntensityInput IntensityInput { get; set; }
        public Predicate<float> ValueSelector { get; set; }
        public override bool IdleValue => IntensityInput != null && ValueSelector(IntensityInput.IdleValue);
        public override IInputSource Source => IntensityInput?.Source;
        public override bool Value => IntensityInput != null && ValueSelector(IntensityInput.Value);

        public override string DisplayName
        {
            get
            {
                if (IntensityInput == null)
                    return "";

                string name = ValueSelector.Method.GetDelegateName();
                if (string.IsNullOrEmpty(name))
                    return $"{IntensityInput.DisplayName}";

                return $"{IntensityInput.DisplayName} {name}";
            }
        }

        public IntensityToButtonInput()
        {
        }

        public IntensityToButtonInput(IIntensityInput intensityInput, Predicate<float> valueSelector)
        {
            IntensityInput = intensityInput;
            ValueSelector = valueSelector;
        }
        
        public override void Update()
        {
            IntensityInput.Update();
            base.Update();
        }
    }
}