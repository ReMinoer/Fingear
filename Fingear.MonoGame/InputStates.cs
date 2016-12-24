using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public interface IInputStates
    {
        KeyboardState KeyboardState { get; }
        MouseState MouseState { get; }
        ReadOnlyDictionary<PlayerIndex, GamePadState> GamePadStates { get; }
        void Update();
        void Reset();
    }
}