using System;
using System.Collections.Generic;
using System.Linq;
using Fingear.MonoGame.Inputs;
using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public class GamePadSource : IInputSource
    {
        private Dictionary<GamePadButton, GamePadButtonInput> _buttons;
        private Dictionary<GamePadTrigger, GamePadTriggerInput> _triggers;
        private Dictionary<GamePadThumbstick, GamePadThumbstickInput> _thumbsticks;
        public PlayerIndex PlayerIndex { get; }
        public string DisplayName => $"GamePad {Enum.GetName(typeof(PlayerIndex),PlayerIndex)}";

        public IEnumerable<IInput> InstantiatedInputs
        {
            get
            {
                if (_buttons != null)
                    foreach (GamePadButtonInput input in _buttons.Values)
                        yield return input;
                if (_triggers != null)
                    foreach (GamePadTriggerInput input in _triggers.Values)
                        yield return input;
                if (_thumbsticks != null)
                    foreach (GamePadThumbstickInput input in _thumbsticks.Values)
                        yield return input;
            }
        }

        public GamePadButtonInput this[GamePadButton button]
        {
            get
            {
                GamePadButtonInput input;
                if (_buttons == null)
                    _buttons = new Dictionary<GamePadButton, GamePadButtonInput>();
                else if (_buttons.TryGetValue(button, out input))
                    return input;

                input = new GamePadButtonInput(button, PlayerIndex);
                _buttons.Add(button, input);
                return input;
            }
        }

        public GamePadTriggerInput this[GamePadTrigger trigger]
        {
            get
            {
                GamePadTriggerInput input;
                if (_triggers == null)
                    _triggers = new Dictionary<GamePadTrigger, GamePadTriggerInput>();
                else if (_triggers.TryGetValue(trigger, out input))
                    return input;

                input = new GamePadTriggerInput(trigger, PlayerIndex);
                _triggers.Add(trigger, input);
                return input;
            }
        }

        public GamePadThumbstickInput this[GamePadThumbstick thumbstick]
        {
            get
            {
                GamePadThumbstickInput input;
                if (_thumbsticks == null)
                    _thumbsticks = new Dictionary<GamePadThumbstick, GamePadThumbstickInput>();
                else if (_thumbsticks.TryGetValue(thumbstick, out input))
                    return input;

                input = new GamePadThumbstickInput(thumbstick, PlayerIndex);
                _thumbsticks.Add(thumbstick, input);
                return input;
            }
        }
        
        internal GamePadSource(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }

        public IEnumerable<IInput> GetAllInputs()
        {
            // Buttons
            yield return new GamePadButtonInput(GamePadButton.Up, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Down, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Left, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Right, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.A, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.B, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.X, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Y, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Back, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.Start, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.BigButton, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.LB, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.RB, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.LS, PlayerIndex);
            yield return new GamePadButtonInput(GamePadButton.RS, PlayerIndex);

            // Triggers
            yield return new GamePadTriggerInput(GamePadTrigger.Left, PlayerIndex);
            yield return new GamePadTriggerInput(GamePadTrigger.Right, PlayerIndex);

            // Thumbsticks
            yield return new GamePadThumbstickInput(GamePadThumbstick.Left, PlayerIndex);
            yield return new GamePadThumbstickInput(GamePadThumbstick.Right, PlayerIndex);
        }
    }
}