using Fingear.Inputs;
using Fingear.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Vector2 = System.Numerics.Vector2;

namespace Fingear.MonoGame.Inputs
{
    public class MouseCursorInput : CursorInputBase, IVirtualInput<Vector2>
    {
        public override string DisplayName => "Mouse";
        public override IInputSource Source => InputSystem.Instance.Mouse;
        public override Vector2 Value => InputSystem.Instance.InputStates.MouseState.Position.AsSystemVector();
        public override Vector2 Maximum => new Vector2(float.PositiveInfinity, float.PositiveInfinity);
        public override Vector2 Minimum => Vector2.Zero;
        public Vector2 DefaultValue { get; set; }
        public Range<Vector2>? ClampBounds { get; set; }

        Vector2 IVirtualInput<Vector2>.Value
        {
            get => Value;
            set => SetMousePosition(value);
        }
        
        internal MouseCursorInput()
        {
        }

        protected override void UpdateValues()
        {
            base.UpdateValues();
            if (ClampBounds.HasValue)
                SetMousePosition(Vector2.Clamp(CurrentValue, ClampBounds.Value.Minimum, ClampBounds.Value.Maximum));
        }

        public void SetToDefault()
        {
            SetMousePosition(DefaultValue);
        }

        public void SetMousePosition(Point position)
        {
            Mouse.SetPosition(position.X, position.Y);
            CurrentValue = position.AsSystemVector();
        }

        private void SetMousePosition(Vector2 position)
        {
            Mouse.SetPosition((int)position.X, (int)position.Y);
            CurrentValue = position;
        }
    }
}