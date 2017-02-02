namespace Fingear.MonoGame
{
    static public class Vector2Extension
    {
        static public Microsoft.Xna.Framework.Vector2 AsMonoGameVector(this System.Numerics.Vector2 vector2)
        {
            return new Microsoft.Xna.Framework.Vector2(vector2.X, vector2.Y);
        }

        static public System.Numerics.Vector2 AsSystemVector(this Microsoft.Xna.Framework.Vector2 vector)
        {
            return new System.Numerics.Vector2(vector.X, vector.Y);
        }
    }
}