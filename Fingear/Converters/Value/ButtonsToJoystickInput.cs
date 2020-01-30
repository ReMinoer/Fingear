using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;

namespace Fingear.Converters.Value
{
    public class ButtonsToJoystickInput : ForceInputBase<Vector2>, IJoystickInput
    {
        public IButtonInput Left { get; set; }
        public IButtonInput Right { get; set; }
        public IButtonInput Up { get; set; }
        public IButtonInput Down { get; set; }
        
        protected override IEnumerable<IInput> BaseInputs => Buttons;
        public IEnumerable<IButtonInput> Buttons
        {
            get
            {
                yield return Left;
                yield return Right;
                yield return Up;
                yield return Down;
            }
        }

        public override string DisplayName => $"{Left} {Right} {Up} {Down}";
        public override IInputSource Source => Left.Source;

        public override Vector2 Value
        {
            get
            {
                Vector2 value = IdleValue;
                if (Left != null && Left.Value)
                    value.X += Minimum.X - IdleValue.X;
                if (Right != null && Right.Value)
                    value.X += Maximum.X - IdleValue.X;
                if (Up != null && Up.Value)
                    value.Y += Maximum.Y - IdleValue.Y;
                if (Down != null && Down.Value)
                    value.Y += Minimum.Y - IdleValue.Y;
                return value;
            }
        }

        public override Vector2 IdleValue => Vector2.Zero;
        public Vector2 Maximum { get; set; } = Vector2.One;
        public Vector2 Minimum { get; set; } = -Vector2.One;
        public Vector2 Delta => Vector2.Min(Maximum - IdleValue, IdleValue - Minimum);

        public ButtonsToJoystickInput()
        {
        }

        public ButtonsToJoystickInput(IButtonInput left, IButtonInput right, IButtonInput up, IButtonInput down)
        {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }

        public override void Update()
        {
            Left.Update();
            Right.Update();
            Up.Update();
            Down.Update();
            base.Update();
        }
    }
}