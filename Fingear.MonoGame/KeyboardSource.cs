using System;
using System.Collections.Generic;
using System.Linq;
using Fingear.MonoGame.Inputs;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public class KeyboardSource : IInputSource
    {
        private Dictionary<Keys, KeyInput> _keys;
        public string DisplayName => "Keyboard";
        public InputSourceType Type => InputSourceType.Keyboard;

        public IEnumerable<IInput> InstantiatedInputs
        {
            get
            {
                if (_keys == null)
                    return Enumerable.Empty<IInput>();
                return _keys.Values;
            }
        }

        public KeyInput this[Keys key]
        {
            get
            {
                KeyInput input;
                if (_keys == null)
                    _keys = new Dictionary<Keys, KeyInput>();
                else if (_keys.TryGetValue(key, out input))
                    return input;

                input = new KeyInput(key);
                _keys.Add(key, input);
                return input;
            }
        }

        public (KeyInput, KeyInput) this[Keys key1, Keys key2] => (this[key1], this[key2]);
        public (KeyInput, KeyInput, KeyInput, KeyInput) this[Keys key1, Keys key2, Keys key3, Keys key4] => (this[key1], this[key2], this[key3], this[key4]);

        internal KeyboardSource()
        {
        }

        public IEnumerable<IInput> GetAllInputs()
        {
            return Enum.GetValues(typeof(Keys)).Cast<Keys>().Select(key => new KeyInput(key));
        }
    }
}