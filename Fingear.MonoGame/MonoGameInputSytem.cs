using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public class MonoGameInputSytem
    {
        static private MonoGameInputSytem _instance;
        static public MonoGameInputSytem Instance => _instance ?? (_instance = new MonoGameInputSytem());

        private IInputStates _inputStates;
        private readonly List<IInputSource> _sources = new List<IInputSource>();
        public IReadOnlyCollection<IInputSource> Sources { get; }

        public IInputStates InputStates
        {
            get => _inputStates ?? (_inputStates = new GameInputStates());
            set => _inputStates = value;
        }

        private MonoGameInputSytem()
        {
            Sources = _sources.AsReadOnly();

            _sources.Add(new KeyboardSource());
            _sources.Add(new MouseSource());
            _sources.Add(new GamePadSource(PlayerIndex.One));
            _sources.Add(new GamePadSource(PlayerIndex.Two));
            _sources.Add(new GamePadSource(PlayerIndex.Three));
            _sources.Add(new GamePadSource(PlayerIndex.Four));
        }
    }
}