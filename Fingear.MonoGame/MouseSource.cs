using System.Collections.Generic;
using Fingear.MonoGame.Inputs;

namespace Fingear.MonoGame
{
    public class MouseSource : IInputSource
    {
        private MouseWheelInput _wheel;
        private MouseCursorInput _cursor;
        private Dictionary<MouseButton, MouseButtonInput> _buttons;

        public string DisplayName => "Mouse";
        public MouseWheelInput Wheel => _wheel ?? (_wheel = new MouseWheelInput());
        public MouseCursorInput Cursor => _cursor ?? (_cursor = new MouseCursorInput());

        public IEnumerable<IInput> InstantiatedInputs
        {
            get
            {
                if (_buttons != null)
                    foreach (MouseButtonInput input in _buttons.Values)
                        yield return input;
                if (_wheel != null)
                    yield return _wheel;
                if (_cursor != null)
                    yield return _cursor;
            }
        }

        public MouseButtonInput this[MouseButton button]
        {
            get
            {
                MouseButtonInput input;
                if (_buttons == null)
                    _buttons = new Dictionary<MouseButton, MouseButtonInput>();
                else if (_buttons.TryGetValue(button, out input))
                    return input;

                input = new MouseButtonInput(button);
                _buttons.Add(button, input);
                return input;
            }
        }

        internal MouseSource()
        {
        }

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