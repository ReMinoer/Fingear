using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public class InputStates : IInputStates
    {
        private KeyboardState? _keyboardState;
        private MouseState? _mouseState;
        private Dictionary<PlayerIndex, GamePadState> _gamePadStates;
        public bool Ignored { get; private set; }

        public KeyboardState KeyboardState
        {
            get
            {
                if (_keyboardState == null)
                    _keyboardState = Ignored ? new KeyboardState() : Keyboard.GetState();
                return _keyboardState.Value;
            }
        }

        public MouseState MouseState
        {
            get
            {
                if (_mouseState == null)
                    _mouseState = Ignored ? new MouseState() : Mouse.GetState();
                return _mouseState.Value;
            }
        }

        public GamePadState this[PlayerIndex playerIndex]
        {
            get
            {
                GamePadState gamePadState;
                if (_gamePadStates == null)
                    _gamePadStates = new Dictionary<PlayerIndex, GamePadState>();
                else if (_gamePadStates.TryGetValue(playerIndex, out gamePadState))
                    return gamePadState;

                gamePadState = Ignored ? new GamePadState() : GamePad.GetState(playerIndex);
                _gamePadStates.Add(playerIndex, gamePadState);
                return gamePadState;
            }
        }

        public void Clean()
        {
            _keyboardState = null;
            _mouseState = null;
            _gamePadStates?.Clear();

            Ignored = false;
        }

        public void Reset()
        {
        }

        public void Ignore()
        {
            Ignored = true;
        }
    }
}