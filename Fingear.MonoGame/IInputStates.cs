using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Fingear.MonoGame
{
    public interface IInputStates : Fingear.Inputs.IInputStates
    {
        KeyboardState KeyboardState { get; }
        MouseState MouseState { get; }
        GamePadState this[PlayerIndex playerIndex] { get; }
    }
}