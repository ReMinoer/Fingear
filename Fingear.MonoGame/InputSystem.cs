using System.Collections.Generic;
using Fingear.Inputs;
using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public class InputSystem
    {
        static private InputSystem _instance;
        static public InputSystem Instance => _instance ?? (_instance = new InputSystem());

        private IInputStates _inputStates;
        private KeyboardSource _keyboard;
        private MouseSource _mouse;
        private Dictionary<PlayerIndex, GamePadSource> _gamePads;
        public KeyboardSource Keyboard => _keyboard ?? (_keyboard = new KeyboardSource());
        public MouseSource Mouse => _mouse ?? (_mouse = new MouseSource());

        public GamePadSource this[PlayerIndex playerIndex]
        {
            get
            {
                GamePadSource gamePad;
                if (_gamePads == null)
                    _gamePads = new Dictionary<PlayerIndex, GamePadSource>();
                else if (_gamePads.TryGetValue(playerIndex, out gamePad))
                    return gamePad;

                gamePad = new GamePadSource(playerIndex);
                _gamePads.Add(playerIndex, gamePad);
                return gamePad;
            }
        }

        public IInputStates InputStates
        {
            get => _inputStates ?? (_inputStates = new InputStates());
            set => _inputStates = value;
        }

        public IEnumerable<IInputSource> Sources
        {
            get
            {
                yield return Keyboard;
                yield return Mouse;
                yield return this[PlayerIndex.One];
                yield return this[PlayerIndex.Two];
                yield return this[PlayerIndex.Three];
                yield return this[PlayerIndex.Four];
            }
        }

        private InputSystem()
        {
        }
    }
}