using System.Collections.Generic;
using Fingear.MonoGame.Inputs.GamePad;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
            yield return new GamePadButtonInput(PlayerIndex, Buttons.A);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.B);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.X);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.Y);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.Back);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.Start);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.BigButton);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.LeftShoulder);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.RightShoulder);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.DPadUp);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.DPadRight);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.DPadDown);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.DPadLeft);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.LeftStick);
            yield return new GamePadButtonInput(PlayerIndex, Buttons.RightStick);

            // Triggers
            yield return new GamePadTriggerInput(PlayerIndex, GamePadTrigger.Left);
            yield return new GamePadTriggerInput(PlayerIndex, GamePadTrigger.Right);

            // Thumbsticks
            yield return new GamePadThumbstickInput(PlayerIndex, GamePadThumbstick.Left);
            yield return new GamePadThumbstickInput(PlayerIndex, GamePadThumbstick.Right);
        }
    }
}