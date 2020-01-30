using System;
using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class ScalesToCursorInput : PositionInputBase<Vector2>, ICursorInput
    {
        public IScaleInput X { get; set; }
        public IScaleInput Y { get; set; }
        
        protected override IEnumerable<IInput> BaseInputs => Scales;
        public IEnumerable<IScaleInput> Scales
        {
            get
            {
                yield return X;
                yield return Y;
            }
        }

        public override string DisplayName => $"{X} {Y}";
        public override IInputSource Source => X.Source;

        public override Vector2 Value => new Vector2(X.Value, Y.Value).ReLerp(new Vector2(X.Minimum, Y.Minimum), new Vector2(X.Maximum, Y.Maximum), Minimum, Maximum);
        public Vector2 Delta => new Vector2(X.Delta, Y.Delta);

        public Vector2 Maximum { get; set; } = Vector2.One;
        public Vector2 Minimum { get; set; } = Vector2.Zero;

        public ScalesToCursorInput()
        {
        }

        public ScalesToCursorInput(IScaleInput x, IScaleInput y)
        {
            X = x;
            Y = y;
        }

        public override void Update()
        {
            X.Update();
            Y.Update();
            base.Update();
        }
    }
}