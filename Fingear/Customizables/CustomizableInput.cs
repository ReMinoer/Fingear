namespace Fingear.Customizables
{
    public class CustomizableInput<TInput> : ICustomizableInput<TInput>
        where TInput : IInput
    {
        public TInput Input { get; set; }
        public string DisplayName => Input?.DisplayName ?? "";
        public InputActivity Activity => Input?.Activity ?? InputActivity.Idle;
        public IInputSource Source => Input?.Source;
        public bool Updated => Input.Updated;
        IInput ICustomizableInput.Input => Input;
        public void Prepare() => Input.Prepare();
        public void Update() => Input.Update();
        public void Reset() => Input.Reset();
    }

    public class CustomizableInput<TInput, TValue> : CustomizableInput<TInput>, ICustomizableInput<TInput, TValue>
        where TInput : IInput<TValue>
    {
        public virtual TValue Value => Input != null ? Input.Value : default(TValue);
    }
}