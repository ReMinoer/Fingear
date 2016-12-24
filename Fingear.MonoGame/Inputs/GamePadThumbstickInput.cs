using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public class GamePadThumbstickInput : JoystickInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public GamePadThumbstick Thumbstick { get; }
        public override IInputSource Source => new GamePadSource(PlayerIndex);
        public override Vector2 Maximum => new Vector2(1, 1);
        public override Vector2 Minimum => new Vector2(-1, -1);
        public override Vector2 IdleValue => new Vector2(0, 0);

        public override string DisplayName
        {
            get
            {
                switch (Thumbstick)
                {
                    case GamePadThumbstick.Left: return "Left Thumbstick";
                    case GamePadThumbstick.Right: return "Right Thumbstick";
                    default: throw new NotSupportedException();
                }
            }
        }

        public override Vector2 Value
        {
            get
            {
                GamePadState gamePadState = MonoGameInputSytem.Instance.InputStates.GamePadStates[PlayerIndex];
                switch (Thumbstick)
                {
                    case GamePadThumbstick.Left: return gamePadState.ThumbSticks.Left.AsFingearVector();
                    case GamePadThumbstick.Right: return gamePadState.ThumbSticks.Right.AsFingearVector();
                    default: throw new NotSupportedException();
                }
            }
        }

        public GamePadThumbstickInput(GamePadThumbstick thumbstick, PlayerIndex playerIndex = PlayerIndex.One)
        {
            PlayerIndex = playerIndex;
            Thumbstick = thumbstick;
        }
    }
}