using Microsoft.Xna.Framework;
using Vector2 = System.Numerics.Vector2;

namespace Fingear.MonoGame
{
    static public class PointExtension
    {
        static public Point AsMonoGamePoint(this Vector2 vector2)
        {
            return new Point((int)vector2.X, (int)vector2.Y);
        }

        static public Vector2 AsSystemVector(this Point vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}