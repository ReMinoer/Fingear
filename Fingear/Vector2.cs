using System;
using Fingear.Utils;

namespace Fingear
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X { get; set; }
        public float Y { get; set; }
        static public Vector2 Zero => new Vector2();
        static public Vector2 UnitX => new Vector2(1, 0);
        static public Vector2 UnixY => new Vector2(0, 1);
        static public Vector2 One => new Vector2(1, 1);
        public float Length => (float)Math.Sqrt(X * X + Y * Y);
        public Vector2 Normalized => this / Length;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Vector2 other)
        {
            return X.FloatEquals(other.X) && Y.FloatEquals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Vector2 && Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public float Dot(Vector2 b, Vector2 c)
        {
            return b.X * c.X + b.Y * c.Y;
        }

        static public Vector2 operator -(Vector2 b)
        {
            return new Vector2
            {
                X = -b.X,
                Y = -b.Y
            };
        }

        static public Vector2 operator +(Vector2 b, Vector2 c)
        {
            return new Vector2
            {
                X = b.X + c.X,
                Y = b.Y + c.Y
            };
        }

        static public Vector2 operator -(Vector2 b, Vector2 c)
        {
            return new Vector2
            {
                X = b.X - c.X,
                Y = b.Y - c.Y
            };
        }

        static public Vector2 operator *(Vector2 b, float c)
        {
            return new Vector2
            {
                X = b.X * c,
                Y = b.Y * c
            };
        }

        static public Vector2 operator *(Vector2 b, Vector2 c)
        {
            return new Vector2
            {
                X = b.X * c.X,
                Y = b.Y * c.Y
            };
        }

        static public Vector2 operator /(Vector2 b, float c)
        {
            return new Vector2
            {
                X = b.X / c,
                Y = b.Y / c
            };
        }

        static public Vector2 operator /(Vector2 b, Vector2 c)
        {
            return new Vector2
            {
                X = b.X / c.X,
                Y = b.Y / c.Y
            };
        }

        static public bool operator==(Vector2 b, Vector2 c)
        {
            return b.X.FloatEquals(c.X) && b.Y.FloatEquals(c.Y);
        }

        static public bool operator!=(Vector2 b, Vector2 c)
        {
            return !b.X.FloatEquals(c.X) || !b.Y.FloatEquals(c.Y);
        }
    }
}