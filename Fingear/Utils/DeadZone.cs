using System;
using System.Numerics;
using Fingear.Inputs.Converters;

namespace Fingear.Utils
{
    static public class DeadZone
    {
        static public Predicate<float> Radius(float minimumRange)
        {
            return value => value >= minimumRange || value <= -minimumRange;
        }

        static public Predicate<float> Plus(float other)
        {
            return value => value >= other;
        }

        static public Predicate<float> Minus(float other)
        {
            return value => value <= other;
        }

        static public Predicate<Vector2> Plus(Axis axis, float other)
        {
            switch (axis)
            {
                case Axis.X: return value => value.X >= other;
                case Axis.Y: return value => value.Y >= other;
                default: throw new NotSupportedException();
            }
        }

        static public Predicate<Vector2> Minus(Axis axis, float other)
        {
            switch (axis)
            {
                case Axis.X: return value => value.X <= other;
                case Axis.Y: return value => value.Y <= other;
                default: throw new NotSupportedException();
            }
        }


        static public Predicate<Vector2> VectorRadius(float minimumLength)
        {
            return value => value.Length() >= minimumLength;
        }

        static public Predicate<Vector2> Range(Vector2 minimumRange)
        {
            return value => value.X >= minimumRange.X || value.X <= -minimumRange.X && value.Y >= minimumRange.Y || value.Y <= -minimumRange.Y;
        }
    }
}