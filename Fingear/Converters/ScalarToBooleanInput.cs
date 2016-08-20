namespace Fingear.Converters
{
    public class ScalarToBooleanInput : IBooleanInput
    {
        public IScalarInput ScalarInput { get; set; }
        public float Deadzone { get; set; }
        public string DisplayName => ScalarInput?.DisplayName ?? "";
        public InputActivity Activity => ScalarInput?.Activity ?? InputActivity.Idle;
        public IInputSource Source => ScalarInput?.Source;
        public bool Value => ScalarInput != null && ScalarInput.Value >= Deadzone;

        public ScalarToBooleanInput()
        {
        }

        public ScalarToBooleanInput(IScalarInput scalarInput, float deadzone)
        {
            ScalarInput = scalarInput;
            Deadzone = deadzone;
        }
        
        public void Update()
        {
            ScalarInput.Update();
        }
    }
}