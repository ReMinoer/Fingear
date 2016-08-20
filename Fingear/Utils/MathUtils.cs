using System.Linq.Expressions;

namespace Fingear.Utils
{
    static public class MathUtils
    {
        static public bool FloatEquals(this float a, float b)
        {
            return System.Math.Abs(a - b) < float.Epsilon;
        }

        static public float Lerp(float min, float max, float t)
        {
            return min + (max - min) * t;
        }

        static public Vector2 Lerp(Vector2 min, Vector2 max, float t)
        {
            return min + (max - min) * t;
        }

        static public Vector2 Lerp(Vector2 min, Vector2 max, Vector2 t)
        {
            return min + (max - min) * t;
        }

        static public float InverseLerp(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

        static public Vector2 InverseLerp(Vector2 value, Vector2 min, Vector2 max)
        {
            return (value - min) / (max - min);
        }

        static public float ReLerp(float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            return Lerp(InverseLerp(value, oldMin, oldMax), newMin, newMax);
        }

        static public Vector2 ReLerp(Vector2 value, Vector2 oldMin, Vector2 oldMax, Vector2 newMin, Vector2 newMax)
        {
            return Lerp(InverseLerp(value, oldMin, oldMax), newMin, newMax);
        }
    }
}