﻿namespace Fingear.Customizables
{
    public class CustomizableInput<TInput> : ICustomizableInput<TInput>
        where TInput : IInput
    {
        public TInput Input { get; set; }
        public string DisplayName => Input?.DisplayName ?? "";
        public InputActivity Activity => Input?.Activity ?? InputActivity.Idle;
        public IInputSource Source => Input?.Source;
        IInput ICustomizableInput.Input => Input;

        public void Update()
        {
            Input?.Update();
        }
    }

    public class CustomizableInput<TInput, TValue> : CustomizableInput<TInput>, IInput<TValue>
        where TInput : class, IInput<TValue>
    {
        public TValue Value => Input != null ? Input.Value : default(TValue);
    }
}