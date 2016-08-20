﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public class InputStates
    {
        static private InputStates _instance;
        static public InputStates Instance => _instance ?? (_instance = new InputStates());
        private readonly Dictionary<PlayerIndex, GamePadState> _gamePadStates;
        private readonly PlayerIndex[] _padPlayerIndexes;
        public KeyboardState KeyboardState { get; private set; }
        public MouseState MouseState { get; private set; }
        public ReadOnlyDictionary<PlayerIndex, GamePadState> GamePadStates { get; private set; }

        private InputStates()
        {
            _gamePadStates = new Dictionary<PlayerIndex, GamePadState>();
            _padPlayerIndexes = Enum.GetValues(typeof(PlayerIndex)) as PlayerIndex[];
            if (_padPlayerIndexes == null)
                return;

            foreach (PlayerIndex playerIndex in _padPlayerIndexes)
                _gamePadStates[playerIndex] = new GamePadState();

            GamePadStates = new ReadOnlyDictionary<PlayerIndex, GamePadState>(_gamePadStates);

            Reset();
        }

        public void Update()
        {
            KeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
            foreach (PlayerIndex playerIndex in _padPlayerIndexes)
                _gamePadStates[playerIndex] = GamePad.GetState(playerIndex);
        }

        public void Reset()
        {
            KeyboardState = new KeyboardState();
            MouseState = new MouseState();
            foreach (PlayerIndex playerIndex in _padPlayerIndexes)
                _gamePadStates[playerIndex] = new GamePadState();
        }
    }
}