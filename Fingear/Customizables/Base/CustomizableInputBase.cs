namespace Fingear.Customizables.Base
{
    public class CustomizableInputBase<TInput> : IInput
        where TInput : IInput
    {
        public TInput Input { get; set; }
        public InputActivity Activity => Input?.Activity ?? InputActivity.Idle;
        public IInputSource Source => Input?.Source;

        public void Update()
        {
            Input?.Update();
        }
    }
}