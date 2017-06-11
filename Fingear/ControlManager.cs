using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Diese.Collections;

namespace Fingear
{
    public class ControlManager
    {
        private readonly List<IControl> _controls = new List<IControl>();
        private readonly HashSet<IInputSource> _sources = new HashSet<IInputSource>();
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
            _controls.Clear();
            _sources.Clear();

            States.Clean();
            InputManager.Instance.Update();

            _controls.AddRange(Layers.Where(x => x.Enabled).SelectMany(x => x));
            if (_controls.Count == 0)
                return;

            foreach (IControl control in _controls)
                control.Update(elapsedSeconds);

            foreach (IInputSource source in _controls.Where(control => control.IsActive()).SelectMany(control => control.Sources))
                _sources.Add(source);

            if (InputSources.SetEquals(_sources))
                return;

            InputSources = _sources.ToArray().AsReadOnly();
            InputSourcesChanged?.Invoke(InputSources);
        }

        public void IgnoreUpdate()
        {
            States.Ignore();
        }
    }
}