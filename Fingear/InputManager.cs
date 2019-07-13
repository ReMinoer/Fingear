using System;
using System.Collections.Generic;
using System.Linq;
using Diese.Collections;
using Diese.Collections.ReadOnly;

namespace Fingear
{
    public class InputManager
    {
        static private InputManager _instance;
        static public InputManager Instance => _instance ?? (_instance = new InputManager());

        private readonly List<IInput> _inputs = new List<IInput>();
        public IReadOnlyCollection<IInput> Inputs { get; }
        public IReadOnlyCollection<IInputSource> InputSources { get; private set; }
        public IInputStates InputStates { get; set; }

        public event Action<IEnumerable<IInputSource>> InputSourcesChanged;

        private InputManager()
        {
            Inputs = _inputs.AsReadOnly();
            InputSources = ReadOnlyCollection<IInputSource>.Empty;
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

            IInputSource[] sources = Inputs.Where(x => x.Activity.IsPressed()).Select(x => x.Source).Distinct().ToArray();
            if (!InputSources.SetEquals(sources))
            {
                InputSources = sources.AsReadOnly();
                InputSourcesChanged?.Invoke(InputSources);
            }
        }
    }
}