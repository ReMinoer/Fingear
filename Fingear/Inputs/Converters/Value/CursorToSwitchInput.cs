﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Inputs.Converters.Value
{
    public class CursorToSwitchInput : PositionInputBase<bool>, ISwitchInput
    {
        public ICursorInput CursorInput { get; set; }
        public Predicate<Vector2> ValueSelector { get; set; }

        public override IInputSource Source => CursorInput?.Source;
        public override bool Value => CursorInput != null && ValueSelector(CursorInput.Value);

        protected override IEnumerable<IInput> BaseInputs
        {
            get { yield return CursorInput; }
        }

        public override string DisplayName
        {
            get
            {
                if (CursorInput == null)
                    return "";

                string name = ValueSelector.GetMethodInfo().GetDelegateName();
                if (string.IsNullOrEmpty(name))
                    return $"{CursorInput.DisplayName}";

                return $"{CursorInput.DisplayName} {name}";
            }
        }

        public CursorToSwitchInput()
        {
        }

        public CursorToSwitchInput(ICursorInput cursorInput, Predicate<Vector2> valueSelector)
        {
            CursorInput = cursorInput;
            ValueSelector = valueSelector;
        }

        public override void Update()
        {
            CursorInput.Update();
            base.Update();
        }
    }
}