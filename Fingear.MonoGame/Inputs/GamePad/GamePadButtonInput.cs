using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs.GamePad
{
    public class GamePadButtonInput : ButtonInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public Buttons Button { get; }
        public override IInputSource Source => new GamePadSource(PlayerIndex);
        public override bool Value => InputStates.Instance.GamePadStates[PlayerIndex].IsButtonDown(Button);

        public GamePadButtonInput(PlayerIndex playerIndex, Buttons button)
        {
            PlayerIndex = playerIndex;
            Button = button;
        }
    }
}