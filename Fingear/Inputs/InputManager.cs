using System;
using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Diese.Collections.ReadOnly;

namespace Fingear.Inputs
{
    public class InputManager
    {
        static private InputManager _instance;
        static public InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<IInput> _inputs = new List<IInput>();
        public IReadOnlyCollection<IInput> Inputs { get; }
        public IReadOnlyCollection<IInputSource> PressedInputSources { get; private set; }
        public IInputStates InputStates { get; set; }

        public event Action<IReadOnlyCollection<IInputSource>> InputSourcesUsed;

        private InputManager()
        {
            Inputs = _inputs.AsReadOnly();
            PressedInputSources = ReadOnlyCollection<IInputSource>.Empty;
        }

        internal void Register(IInput input)
        {
            _inputs.Add(input);
        }

        public void Update()
        {
            InputStates.Clean();

            foreach (IInput input in Inputs)
                input.Prepare();

            foreach (IInput input in Inputs)
                input.Update();
            
            IInputSource[] changedInputSources = Inputs.Where(x => x.Activity.IsChanged()).Select(x => x.Source).Distinct().ToArray();
            if (changedInputSources.Length > 0)
                InputSourcesUsed?.Invoke(changedInputSources);

            PressedInputSources = Inputs.Where(x => x.Activity.IsPressed()).Select(x => x.Source).Distinct().ToArray().AsReadOnly();
        }

        public void Reset()
        {
            InputStates?.Reset();
            foreach (IInput input in Inputs)
                input.Reset();
        }
    }
}