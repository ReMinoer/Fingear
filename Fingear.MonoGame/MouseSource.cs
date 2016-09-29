using System.Collections.Generic;
using Fingear.MonoGame.Inputs;

namespace Fingear.MonoGame
{
    public struct MouseSource : IInputSource
    {
        public string DisplayName => "Mouse";

        public IEnumerable<IInput> GetAllInputs()
        {
            // Buttons
            yield return new MouseButtonInput(MouseButton.Left);
            yield return new MouseButtonInput(MouseButton.Right);
            yield return new MouseButtonInput(MouseButton.Middle);
            yield return new MouseButtonInput(MouseButton.XButton1);
            yield return new MouseButtonInput(MouseButton.XButton2);

            // Wheel
            yield return new MouseWheelInput();

            // Cursor
            yield return new MouseCursorInput();
        }
    }
}