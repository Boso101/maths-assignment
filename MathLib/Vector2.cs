using System;

namespace MathClasses
{
    public class Vector2
    {
        public float x, y;

        //
        // NOTE:
        // These implicit operators will convert between a MathClasses.Vector2 & System.Numerics.Vector2
        // This is useful because Raylib has functions that work nicely with System.Numerics.Vector2, 
        // so we can pass our MathClasses.Vector2 directly to Raylib & let the implicit conversions do their job.         
        public static implicit operator Vector2(System.Numerics.Vector2 v)
        {
            return new Vector2 { x = v.X, y = v.Y };
        }

        public static implicit operator System.Numerics.Vector2(Vector2 v)
        {
            return new System.Numerics.Vector2(v.x, v.y);
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(double x, double y)
        {
            this.x = (float)x;
            this.y = (float)y;
        }

        public static Vector2 CreateRotationVector(float radians)
        {
            return new Vector2(Math.Cos(radians), Math.Sin(radians));
        }

        public float Rotation()
        {
            return (float)Math.Atan2(y, x);
        }

        public void Rotate(float amount)
        {
            var x_rotated = x * Math.Cos(amount) - y * Math.Sin(amount);
            var y_rotated = x * Math.Sin(amount) + y * Math.Cos(amount);

            x = (float)x_rotated;
            y = (float)y_rotated;
        }

        public void RotateAround(Vector2 pos, float amount)
        {
            x -= pos.x;
            y -= pos.y;

            Rotate(amount);

            x += pos.x;
            y += pos.y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public void Normalise()
        {
            float length = Magnitude();
            if (length > 0)
            {
                x /= length;
                y /= length;
            }
        }

        public float Dot(Vector2 rhs)
        {
            return (x * rhs.x) + (y * rhs.y);
        }

        public Vector2 GetPerpendicular()
        {
            return new Vector2(y, -x);
        }

        public static Vector2 Reflect(Vector2 incident, Vector2 normal)
        {
            return incident - (2.0f * Vector2.Dot(incident, normal) * normal);
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.x * rhs.x) + (lhs.y * rhs.y);
        }

        public static Vector2 Normalise(Vector2 vec)
        {
            Vector2 unitVec = new Vector2(vec.x, vec.y);
            unitVec.Normalise();
            return unitVec;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            Vector2 vec = b - a;
            return vec.Magnitude();
        }

        public static Vector2 Add(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }



        public static Vector2 Sub(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 PreScale(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }

        public static Vector2 PostScale(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return Add(lhs, rhs);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return Sub(lhs, rhs);
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x * rhs.x, lhs.y * rhs.y);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }

        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }


    }
}
