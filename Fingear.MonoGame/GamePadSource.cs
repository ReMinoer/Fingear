using System;
using System.Collections.Generic;
using Fingear.MonoGame.Inputs;
using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public struct GamePadSource : IInputSource
    {
        public PlayerIndex PlayerIndex { get; }
        public string DisplayName => $"GamePad {Enum.GetName(typeof(PlayerIndex),PlayerIndex)}";

        public GamePadSource(PlayerIndex playerIndex)
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