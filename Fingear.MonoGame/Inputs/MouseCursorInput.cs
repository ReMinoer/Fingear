using Fingear.Inputs;
using Fingear.Inputs.Base;
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

        private Range<Vector2>? _clampBounds;
        public Range<Vector2>? ClampBounds
        {
            get => _clampBounds;
            set
            {
                _clampBounds = value;
                SetMousePosition(CurrentValue.AsMonoGamePoint());
            }
        }

        Vector2 IVirtualInput<Vector2>.Value
        {
            get => Value;
            set => SetMousePosition(value.AsMonoGamePoint());
        }
        
        internal MouseCursorInput()
        {
        }

        protected override void UpdateValues()
        {
            SetMousePosition(Value.AsMonoGamePoint());
            base.UpdateValues();
        }

        public void SetToDefault()
        {
            SetMousePosition(DefaultValue.AsMonoGamePoint());
        }

        public void SetMousePosition(Point position)
        {
            if (ClampBounds.HasValue)
            {
                position = Vector2.Clamp(position.AsSystemVector(), ClampBounds.Value.Minimum, ClampBounds.Value.Maximum).AsMonoGamePoint();
            }

            if (position == Value.AsMonoGamePoint())
                return;

            Mouse.SetPosition(position.X, position.Y);
        }
    }
}