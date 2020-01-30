using System;
using System.Collections.Generic;
using System.Numerics;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Value
{
    public class IntensitiesToJoystickInput : ForceInputBase<Vector2>, IJoystickInput
    {
        public IIntensityInput X { get; set; }
        public IIntensityInput Y { get; set; }
        
        protected override IEnumerable<IInput> BaseInputs => Intensities;
        public IEnumerable<IIntensityInput> Intensities
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
        public override Vector2 IdleValue => new Vector2(X.IdleValue, Y.IdleValue).ReLerp(new Vector2(X.Minimum, Y.Minimum), new Vector2(X.Maximum, Y.Maximum), Minimum, Maximum);
        public Vector2 Delta => new Vector2(X.Delta, Y.Delta);

        public Vector2 Maximum { get; set; } = Vector2.One;
        public Vector2 Minimum { get; set; } = -Vector2.One;

        public IntensitiesToJoystickInput()
        {
        }

        public IntensitiesToJoystickInput(IIntensityInput x, IIntensityInput y)
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