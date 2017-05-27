using System.Collections.Generic;

namespace Fingear
{
    public class InputManager
    {
        static private InputManager _instance;
        static public InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<IInput> _inputs = new List<IInput>();
        public IReadOnlyCollection<IInput> Inputs { get; }

        private InputManager()
        {
            Inputs = _inputs.AsReadOnly();
        }

        internal void Register(IInput input)
        {
            _inputs.Add(input);
        }

        public void Update()
        {
            foreach (IInput input in Inputs)
                input.Prepare();

            foreach (IInput input in Inputs)
                input.Update();
        }
    }
}