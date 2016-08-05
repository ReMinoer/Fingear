namespace Fingear.MonoGame
{
    static public class Vector2Extension
    {
        static public Microsoft.Xna.Framework.Vector2 AsMonoGameVector(this Vector2 vector2)
        {
            return new Microsoft.Xna.Framework.Vector2(vector2.X, vector2.Y);
        }

        static public Vector2 AsFingearVector(this Microsoft.Xna.Framework.Vector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}