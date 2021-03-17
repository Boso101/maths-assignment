using System;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(double x, double y, double z, double w)
        {
            this.x =(float) x;
            this.y =(float) y;
            this.z =(float) z;
            this.w =(float) w;
        }

        //
        // NOTE:
        // These implicit operators will convert between a MathClasses.Vector4 & System.Numerics.Vector4
        // This is useful because Raylib has functions that work nicely with System.Numerics.Vector4, 
        // so we can pass our MathClasses.Vector4 directly to Raylib & let the implicit conversions do their job.         
        public static implicit operator Vector4(System.Numerics.Vector4 v)
        {
            return new Vector4 { x = v.X, y = v.Y, z = v.Z, w = v.W };
        }

        public static implicit operator System.Numerics.Vector4(Vector4 v)
        {
            return new System.Numerics.Vector4(v.x, v.y, v.z, v.w);
        }

        /// <summary>
        /// Vector4 Addition Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns> Vector4 of added vectors </returns>
        public static Vector4 operator +(Vector4 leftSide, Vector4 rightSide)
        {
            return new Vector4(leftSide.x + rightSide.x, leftSide.y + rightSide.y, + leftSide.z + rightSide.z, leftSide.w + rightSide.w);
        }

        /// <summary>
        /// Vector4 Subtraction Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns> Vector4 of subtracted vectors </returns>
        public static Vector4 operator -(Vector4 leftSide, Vector4 rightSide)
        {
            return new Vector4(leftSide.x - rightSide.x, leftSide.y - rightSide.y, leftSide.z - rightSide.z, leftSide.w - rightSide.w);
        }

        /// <summary>
        /// Vector4 Multiplier Function
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="rightSide"></param>
        /// <returns>Vector4 of the multiplied modifier with Vector </returns>
        public static Vector4 operator *(float multiplier, Vector4 rightSide)
        {
            return new Vector4(rightSide.x * multiplier, rightSide.y * multiplier, rightSide.z * multiplier, rightSide.w * multiplier);
        }

        /// <summary>
        /// Vector4 Multiplier Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="multiplier"></param>
        /// <returns>Vector4 of the multiplied modifier with Vector </returns>
        public static Vector4 operator *(Vector4 leftSide, float multiplier)
        {
            return new Vector4(leftSide.x * multiplier, leftSide.y * multiplier, leftSide.z * multiplier, leftSide.w * multiplier);
        }


        /// <summary>
        /// Vector4 Division Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="divideNumb"></param>
        /// <returns></returns>
        public static Vector4 operator /(Vector4 leftSide, float divideNumb)
        {
            // Use multiplication function to divide
            return leftSide * (1 / divideNumb);
        }






        /// <summary>
        /// Calculate the magnitude of this instance of a Vector4
        /// </summary>
        /// <returns>The magnitude of this Vector 4 </returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w*w);
        }

        /// <summary>
        /// Normalises this instance of a Vector4.
        /// </summary>
        public void Normalize()
        {
            float length = Magnitude();

            if (length > 0)
            {
                x /= length;
                y /= length;
                z /= length;
                w /= length;
            }
        }



        public void SetRotateX(float rotation)
        {

        }

        public void SetRotateY(float rotation)
        {

        }

        public void SetRotateZ(float rotation)
        {

        }

        /// <summary>
        /// Class instance version of Dot
        /// </summary>
        /// <param name="otherVector"></param>
        /// <returns> the Dot Product as a float </returns>
        public float Dot(Vector4 otherVector)
        {
            return (x * otherVector.x) + (y * otherVector.y) + (z * otherVector.z) + (w * otherVector.w);
        }

        /// <summary>
        ///Calculates the cross product of this and another vector4
        /// </summary>
        /// <param name="otherVector"></param>
        /// <returns> Returns Cross Product vector and other vector as a new Vector4</returns>
        public Vector4 Cross(Vector4 otherVector)
        {
            return new Vector4(y * otherVector.z - z * otherVector.y, z * otherVector.x - x * otherVector.z, x * otherVector.y - y * otherVector.x, 0);
        }


    }
}
