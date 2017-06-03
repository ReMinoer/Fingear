using System;
using System.Collections.Generic;
using Fingear.Inputs.Base;

namespace Fingear
{
    public class InputManager
    {
        static private InputManager _instance;
        static public InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<IInput> _inputs = new List<IInput>();
        public IReadOnlyCollection<IInput> Inputs { get; }

        private readonly List<IInput> _handledInputs = new List<IInput>();
        public IReadOnlyCollection<IInput> HandledInputs { get; }

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
            _handledInputs.Clear();

            foreach (IInput input in Inputs)
                input.Prepare();

            foreach (IInput input in Inputs)
                input.Update();
        }

        internal void Handle<TValue>(InputBase<TValue> input)
            where TValue : IEquatable<TValue>
        {
            input.Handled = true;
            _handledInputs.Add(input);
        }
    }
}