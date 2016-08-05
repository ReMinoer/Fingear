using System;

namespace Fingear.Utils
{
    static public class DeadZone
    {
        static public Predicate<float> Scalar(float minimum)
        {
            return value => value >= minimum;
        }

        static public Predicate<Vector2> Vector(float minimumLength)
        {
            return value => value.Length >= minimumLength;
        }

        static public Predicate<Vector2> Vector(Vector2 minimumRange)
        {
            return value => value.X >= minimumRange.X || value.X <= -minimumRange.X && value.Y >= minimumRange.Y || value.Y <= -minimumRange.Y;
        }
    }
}