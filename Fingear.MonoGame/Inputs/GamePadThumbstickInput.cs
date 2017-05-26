using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Vector2 = System.Numerics.Vector2;

namespace Fingear.MonoGame.Inputs
{
    public class GamePadThumbstickInput : JoystickInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public GamePadThumbstick Thumbstick { get; }
        public override IInputSource Source => MonoGameInputSytem.Instance[PlayerIndex];
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
                    case GamePadThumbstick.Left: return gamePadState.ThumbSticks.Left.AsSystemVector();
                    case GamePadThumbstick.Right: return gamePadState.ThumbSticks.Right.AsSystemVector();
                    default: throw new NotSupportedException();
                }
            }
        }

        internal GamePadThumbstickInput(GamePadThumbstick thumbstick, PlayerIndex playerIndex = PlayerIndex.One)
        {
            PlayerIndex = playerIndex;
            Thumbstick = thumbstick;
        }
    }
}