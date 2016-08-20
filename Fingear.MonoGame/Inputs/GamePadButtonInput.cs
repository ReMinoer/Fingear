using System;
using Fingear.Inputs;
using Fingear.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public class GamePadButtonInput : ButtonInputBase
    {
        private readonly Buttons _monogameButton;
        public PlayerIndex PlayerIndex { get; }
        public GamePadButton Button { get; }
        public override string DisplayName => EnumUtils.GetDisplayName(Button);
        public override IInputSource Source => new GamePadSource(PlayerIndex);
        public override bool Value => InputStates.Instance.GamePadStates[PlayerIndex].IsButtonDown(_monogameButton);

        public GamePadButtonInput(PlayerIndex playerIndex, GamePadButton button)
        {
            PlayerIndex = playerIndex;
            Button =  button;
            _monogameButton = MonoGameToXnaButton(button);
        }

        static public GamePadButton? MonoGameToFingearButton(Buttons button)
        {
            switch (button)
            {
                case Buttons.DPadUp: return GamePadButton.Up;
                case Buttons.DPadDown: return GamePadButton.Down;
                case Buttons.DPadLeft: return GamePadButton.Left;
                case Buttons.DPadRight: return GamePadButton.Right;
                case Buttons.A: return GamePadButton.A;
                case Buttons.B: return GamePadButton.B;
                case Buttons.X: return GamePadButton.X;
                case Buttons.Y: return GamePadButton.Y;
                case Buttons.Back: return GamePadButton.Back;
                case Buttons.Start: return GamePadButton.Start;
                case Buttons.BigButton: return GamePadButton.BigButton;
                case Buttons.LeftShoulder: return GamePadButton.LeftShoulder;
                case Buttons.RightShoulder: return GamePadButton.RightShoulder;
                case Buttons.LeftStick: return GamePadButton.LeftStick;
                case Buttons.RightStick: return GamePadButton.RightStick;
                default: return null;
            }
        }

        static public Buttons MonoGameToXnaButton(GamePadButton button)
        {
            switch (button)
            {
                case GamePadButton.Up: return Buttons.DPadUp;
                case GamePadButton.Down: return Buttons.DPadDown;
                case GamePadButton.Left: return Buttons.DPadLeft;
                case GamePadButton.Right: return Buttons.DPadRight;
                case GamePadButton.A: return Buttons.A;
                case GamePadButton.B: return Buttons.B;
                case GamePadButton.X: return Buttons.X;
                case GamePadButton.Y: return Buttons.Y;
                case GamePadButton.Back: return Buttons.Back;
                case GamePadButton.Start: return Buttons.Start;
                case GamePadButton.BigButton: return Buttons.BigButton;
                case GamePadButton.LeftShoulder: return Buttons.LeftShoulder;
                case GamePadButton.RightShoulder: return Buttons.RightShoulder;
                case GamePadButton.LeftStick: return Buttons.LeftStick;
                case GamePadButton.RightStick: return Buttons.RightStick;
                default: throw new NotSupportedException();
            }
        }
    }
}