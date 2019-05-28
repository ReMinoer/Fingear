using System;
using System.Collections.Generic;
using System.Numerics;
using Fingear.Controls.Base;

namespace Fingear.Controls.Gesture
{
    public enum Orientation
    {
        Up,
        Right,
        Down,
        Left
    }

    public class FourDirectionsGestureControl : ControlContainerBase<IControl, Orientation[]>
    {
        private IControl<InputActivity> _activityControl;
        private readonly Stack<Orientation> _currentOrientations = new Stack<Orientation>();
        private Vector2 _currentOrigin;
        public ICursorInput Input { get; set; }
        public float DeadZone { get; set; }

        public IControl<InputActivity> ActivityControl
        {
            get => _activityControl;
            set
            {
                if (_activityControl == value)
                    return;

                if (_activityControl != null)
                    Components.Remove(_activityControl);

                _activityControl = value;

                if (_activityControl != null)
                    Components.Add(_activityControl);
            }
        }

        public override IEnumerable<IInput> Inputs
        {
            get
            {
                foreach (IInput input in base.Inputs)
                    yield return input;
                yield return Input;
            }
        }

        public FourDirectionsGestureControl()
        {
        }

        public FourDirectionsGestureControl(IControl<InputActivity> activityControl, ICursorInput input)
        {
            ActivityControl = activityControl;
            Input = input;
        }

        protected override bool UpdateControlValue(float elapsedTime, out Orientation[] value)
        {
            if (ActivityControl != null && ActivityControl.IsActive(out InputActivity activity))
            {
                switch (activity)
                {
                    case InputActivity.Triggered:
                    {
                        if (Input == null || Input.Activity == InputActivity.Idle)
                            break;

                        _currentOrigin = Input.Value;
                        break;
                    }
                    case InputActivity.Pressed:
                    {
                        if (Input == null || Input.Activity == InputActivity.Idle)
                            break;
                        
                        Vector2 inputValue = Input.Value;
                        Vector2 move = inputValue - _currentOrigin;
                        bool isHorizontal = Math.Abs(move.X) >= Math.Abs(move.Y);

                        Orientation newOrientation;
                        if (isHorizontal)
                        {
                            if (move.X > -DeadZone && move.X < DeadZone)
                                break;
                            newOrientation = move.X >= 0 ? Orientation.Right : Orientation.Left;
                        }
                        else
                        {
                            if (move.Y > -DeadZone && move.Y < DeadZone)
                                break;
                            newOrientation = move.Y >= 0 ? Orientation.Up : Orientation.Down;
                        }

                        // If move continue in same direction, test other axis
                        if (_currentOrientations.Count > 0 && newOrientation == _currentOrientations.Peek())
                        {
                            _currentOrigin = isHorizontal
                                ? new Vector2(inputValue.X, _currentOrigin.Y)
                                : new Vector2(_currentOrigin.X, inputValue.Y);

                            move = inputValue - _currentOrigin;

                            if (isHorizontal)
                            {
                                if (move.Y > -DeadZone && move.Y < DeadZone)
                                    break;
                                newOrientation = move.Y >= 0 ? Orientation.Up : Orientation.Down;
                            }
                            else
                            {
                                if (move.X > -DeadZone && move.X < DeadZone)
                                    break;
                                newOrientation = move.X >= 0 ? Orientation.Right : Orientation.Left;
                            }
                        }

                        _currentOrientations.Push(newOrientation);
                        _currentOrigin = Input.Value;

                        break;
                    }
                    case InputActivity.Released:
                    {
                        value = _currentOrientations.ToArray();
                        _currentOrientations.Clear();

                        return true;
                    }
                    default:
                        throw new NotSupportedException();
                }
            }

            value = new Orientation[0];
            return false;
        }
    }
}