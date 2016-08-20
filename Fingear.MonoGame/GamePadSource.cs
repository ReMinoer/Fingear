using System.Collections.Generic;
using Fingear.MonoGame.Inputs;
using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public struct GamePadSource : IInputSource
    {
        public PlayerIndex PlayerIndex { get; private set; }

        public GamePadSource(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }

        public IEnumerable<IInput> GetAllInputs()
        {
            // Buttons
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Up);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Down);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Left);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Right);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.A);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.B);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.X);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Y);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Back);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.Start);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.BigButton);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.LeftShoulder);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.RightShoulder);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.LeftStick);
            yield return new GamePadButtonInput(PlayerIndex, GamePadButton.RightStick);

            // Triggers
            yield return new GamePadTriggerInput(PlayerIndex, GamePadTrigger.Left);
            yield return new GamePadTriggerInput(PlayerIndex, GamePadTrigger.Right);

            // Thumbsticks
            yield return new GamePadThumbstickInput(PlayerIndex, GamePadThumbstick.Left);
            yield return new GamePadThumbstickInput(PlayerIndex, GamePadThumbstick.Right);
        }
    }
}