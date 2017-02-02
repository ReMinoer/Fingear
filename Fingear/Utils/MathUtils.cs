using System.Numerics;

namespace Fingear.Utils
{
    static public class MathUtils
    {
        static public bool FloatEquals(this float a, float b)
        {
            return System.Math.Abs(a - b) < float.Epsilon;
        }

        static public float Norm(this float a)
        {
            return System.Math.Abs(a);
        }

        static public float Normalized(this float a)
        {
            return System.Math.Sign(a);
        }

        static public float Clamp(this float value, float min, float max)
        {
            return value < min ? min : (value > max ? max : value);
        }

        static public Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max)
        {
            return new Vector2(value.X < min.X ? min.X : (value.X > max.X ? max.X : value.X),
                value.Y < min.Y ? min.Y : (value.Y > max.Y ? max.Y : value.Y));
        }

        static public float Lerp(this float t, float min, float max)
        {
            return min + (max - min) * t;
        }

        static public Vector2 Lerp(this float t, Vector2 min, Vector2 max)
        {
            return min + (max - min) * t;
        }

        static public Vector2 Lerp(this Vector2 t, Vector2 min, Vector2 max)
        {
            return min + (max - min) * t;
        }

        static public float InverseLerp(this float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        static public Vector2 InverseLerp(this Vector2 value, Vector2 min, Vector2 max)
        {
            return (value - min) / (max - min);
        }

        static public float ReLerp(this float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            return value.InverseLerp(oldMin, oldMax).Lerp(newMin, newMax);
        }

        static public Vector2 ReLerp(this Vector2 value, Vector2 oldMin, Vector2 oldMax, Vector2 newMin, Vector2 newMax)
        {
            return value.InverseLerp(oldMin, oldMax).Lerp(newMin, newMax);
        }
    }
}