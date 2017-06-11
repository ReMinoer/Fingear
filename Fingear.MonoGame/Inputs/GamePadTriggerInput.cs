using System;
using Fingear.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public enum GamePadTrigger
    {
        Left,
        Right
    }

    public class GamePadTriggerInput : IntensityInputBase
    {
        public PlayerIndex PlayerIndex { get; }
        public GamePadTrigger Trigger { get; }
        public override IInputSource Source => InputSystem.Instance[PlayerIndex];
        public override float Maximum => 1;
        public override float Minimum => 0;
        public override float IdleValue => 0;

        public override string DisplayName
        {
            get
            {
                switch (Trigger)
                {
                    case GamePadTrigger.Left: return "Left Trigger";
                    case GamePadTrigger.Right: return "Right Trigger";
                    default: throw new NotSupportedException();
                }
            }
        }

        public override float Value
        {
            get
            {
                GamePadState gamePadState = InputSystem.Instance.InputStates[PlayerIndex];
                switch (Trigger)
                {
                    case GamePadTrigger.Left: return gamePadState.Triggers.Left;
                    case GamePadTrigger.Right: return gamePadState.Triggers.Right;
                    default: throw new NotSupportedException();
                }
            }
        }

        internal GamePadTriggerInput(GamePadTrigger trigger, PlayerIndex playerIndex = PlayerIndex.One)
        {
            PlayerIndex = playerIndex;
            Trigger = trigger;
        }
    }
}