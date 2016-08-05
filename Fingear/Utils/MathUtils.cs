namespace Fingear.Utils
{
    static public class MathUtils
    {
        static public bool FloatEquals(this float a, float b)
        {
            return System.Math.Abs(a - b) < float.Epsilon;
        }
    }
}