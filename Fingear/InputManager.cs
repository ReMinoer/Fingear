using System;
using System.Collections.Generic;
using System.Linq;
using Fingear.Inputs.Base;

namespace Fingear
{
    public class InputManager
    {
        static private InputManager _instance;
        static public InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<IInput> _inputs = new List<IInput>();
        public IReadOnlyCollection<IInput> Inputs { get; }

        private readonly List<InputBase> _handledInputs = new List<InputBase>();
        public IReadOnlyCollection<InputBase> HandledInputs { get; }

        private InputManager()
        {
            Inputs = _inputs.AsReadOnly();
            HandledInputs = _handledInputs.AsReadOnly();
        }

        internal void Register(IInput input)
        {
            _inputs.Add(input);
        }

        public void Update()
        {
            if (_handledInputs.Count > 0)
            {
                foreach (InputBase input in _handledInputs.Where(x => x.Activity.IsIdle()).ToArray())
                {
                    input.Handler = null;
                    _handledInputs.Remove(input);
                }
            }

            foreach (IInput input in Inputs)
                input.Prepare();

            foreach (IInput input in Inputs)
                input.Update();
        }

        internal void Handle(InputBase input)
        {
            _handledInputs.Add(input);
        }
    }
}