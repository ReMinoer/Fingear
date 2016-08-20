﻿using Fingear.Inputs;
using Fingear.Utils;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame.Inputs
{
    public class KeyInput : ButtonInputBase
    {
        public Keys Key { get; }
        public override string DisplayName => EnumUtils.GetDisplayName(Key);
        public override IInputSource Source => new KeyboardSource();
        public override bool Value => InputStates.Instance.KeyboardState.IsKeyDown(Key);

        public KeyInput(Keys key)
        {
            Key = key;
        }
    }
}