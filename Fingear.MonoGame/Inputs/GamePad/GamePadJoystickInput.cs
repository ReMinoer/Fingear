using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs.GamePad
{
    public class GamePadThumbstickInput : JoystickInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public GamePadThumbstick Thumbstick { get; }
        public override IInputSource Source => new GamePadSource(PlayerIndex);
        public override Vector2 Maximum => new Vector2(1, 1);
        public override Vector2 Minimum => new Vector2(-1, -1);
        public override Vector2 IdleValue => new Vector2(0, 0);

        public override Vector2 Value
        {
            get
            {
                GamePadState gamePadState = InputStates.Instance.GamePadStates[PlayerIndex];
                switch (Thumbstick)
                {
                    case GamePadThumbstick.Left: return gamePadState.ThumbSticks.Left.AsFingearVector();
                    case GamePadThumbstick.Right: return gamePadState.ThumbSticks.Right.AsFingearVector();
                    default: throw new NotSupportedException();
                }
            }
        }

        public GamePadThumbstickInput(PlayerIndex playerIndex, GamePadThumbstick thumbstick)
        {
            PlayerIndex = playerIndex;
            Thumbstick = thumbstick;
        }
    }
}