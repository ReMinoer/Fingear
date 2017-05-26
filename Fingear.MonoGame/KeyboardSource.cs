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

        internal KeyboardSource()
        {
        }

        public IEnumerable<IInput> GetAllInputs()
        {
            return Enum.GetValues(typeof(Keys)).Cast<Keys>().Select(key => new KeyInput(key));
        }
    }
}