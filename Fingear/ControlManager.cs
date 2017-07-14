using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Diese.Collections;

namespace Fingear
{
    public class ControlManager
    {
        public ObservableCollection<IControlLayer> Layers { get; } = new ObservableCollection<IControlLayer>();
        public IInputStates States { get; set; }
        public IReadOnlyCollection<IInputSource> InputSources { get; private set; }
        public event Action<IEnumerable<IInputSource>> InputSourcesChanged;

        public ControlManager()
        {
            InputSources = Diese.Collections.ReadOnlyCollection<IInputSource>.Empty;
        }

        public void Update(float elapsedSeconds)
        {
            States.Clean();
            InputManager.Instance.Update();

            IControl[] controls = Layers.Where(x => x.Enabled).SelectMany(x => x).ToArray();
            if (controls.Length == 0)
                return;

            foreach (IControl control in controls)
                control.Update(elapsedSeconds);

            IInputSource[] sources = InputManager.Instance.Inputs.Where(x => x.Activity.IsPressed()).Select(x => x.Source).Distinct().ToArray();
            if (!InputSources.SetEquals(sources))
            {
                InputSources = sources.AsReadOnly();
                InputSourcesChanged?.Invoke(InputSources);
            }
        }

        public void IgnoreUpdate()
        {
            States.Ignore();
        }
    }
}