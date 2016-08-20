using System;
using System.Collections.Generic;
using System.Linq;
using Fingear.MonoGame.Inputs;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public struct KeyboardSource : IInputSource
    {
        public IEnumerable<IInput> GetAllInputs()
        {
            return Enum.GetValues(typeof(Keys)).Cast<Keys>().Select(key => new KeyInput(key));
        }
    }
}