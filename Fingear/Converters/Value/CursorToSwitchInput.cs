using System;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class CursorToSwitchInput : PositionInputBase<bool>, ISwitchInput
    {
        public ICursorInput CursorInput { get; set; }
        public Predicate<Vector2> ValueSelector { get; set; }
        public override IInputSource Source => CursorInput?.Source;
        public override bool Value => CursorInput != null && ValueSelector(CursorInput.Value);

        public override string DisplayName
        {
            get
            {
                if (CursorInput == null)
                    return "";

                string name = ValueSelector.Method.GetDelegateName();
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