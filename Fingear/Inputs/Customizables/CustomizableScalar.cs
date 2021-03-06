﻿using Fingear.Utils;

namespace Fingear.Inputs.Customizables
{
    public class CustomizableScale : CustomizableInput<IScaleInput, float>, IScaleInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Delta => Input?.Delta ?? 0f;
        public override float Value => Input?.Value.ReLerp(Input.Minimum, Input.Maximum, Minimum, Maximum) ?? 0f;
    }
}