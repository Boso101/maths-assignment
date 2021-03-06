using System;

namespace MathClasses
{

    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(double x, double y, double z)
        {
            this.x =(float)x;
            this.y =(float)y;
            this.z =(float)z;
        }

        //
        // NOTE:
        // These implicit operators will convert between a MathClasses.Vector3 & System.Numerics.Vector3
        // This is useful because Raylib has functions that work nicely with System.Numerics.Vector3, 
        // so we can pass our MathClasses.Vector3 directly to Raylib & let the implicit conversions do their job.         
        public static implicit operator Vector3(System.Numerics.Vector3 v)
        {
            return new Vector3 { x = v.X, y = v.Y, z = v.Z };
        }

        public static implicit operator System.Numerics.Vector3(Vector3 v)
        {
            return new System.Numerics.Vector3(v.x, v.y, v.z);
        }

      
        /// <summary>
        /// 15/03/21 - Vector3 Addition Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>Vector3 of the added Vectors </returns>
        public static Vector3 operator+(Vector3 leftSide, Vector3 rightSide)
        {
            return new Vector3(leftSide.x + rightSide.x, leftSide.y + rightSide.y, leftSide.z + rightSide.z);
        }

        //15/03/21 
        /// <summary>
        /// Vector3 Multiplier Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="multiplier"></param>
        /// <returns>Vector3 of the multiplied Vector with multiplier </returns>
        public static Vector3 operator *(Vector3 leftSide, float multiplier)
        {
            return new Vector3(leftSide.x*multiplier, leftSide.y * multiplier, leftSide.z * multiplier);
        }


        /// <summary>
        /// Vector3 Multiplier Function
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="rightSide"></param>
        /// <returns>Vector3 of the multiplied modifier with Vector </returns>
        public static Vector3 operator *(float multiplier, Vector3 rightSide)
        {
            return new Vector3(rightSide.x * multiplier, rightSide.y * multiplier, rightSide.z * multiplier);
        }


        /// <summary>
        /// Vector3 Subtraction Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 leftSide, Vector3 rightSide)
        {
            return new Vector3(leftSide.x - rightSide.x, leftSide.y - rightSide.y, leftSide.z - rightSide.z);
        }

        /// <summary>
        /// Vector3 Division Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="divideNumb"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 leftSide, float divideNumb)
        {
            // Use multiplication function to divide
            return leftSide * (1 / divideNumb);
        }

      






        /// <summary>
        /// Calculate the magnitude of this instance of a Vector3
        /// </summary>
        /// <returns>The magnitude of this Vector 3 </returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(MagnitudeSqr());
        }


        /// <summary>
        /// Helper method for getting the magnitude
        /// </summary>
        /// <returns> float of the magnitude squared </returns>
        private float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        /// <summary>
        /// Normalises this instance of a Vector3.
        /// </summary>
        public void Normalize()
        {

            //Magnitude is the length of vector, so lets get it
            float length = Magnitude();
            
            if (length > 0)
            {
                x /= length;
                y /= length;
                z /= length;
            }
        }



       

        /// <summary>
        /// Class instance version of Dot
        /// </summary>
        /// <param name="otherVector"></param>
        /// <returns></returns>
        public float Dot(Vector3 otherVector)
        {
            return (x * otherVector.x) + (y * otherVector.y) + (z * otherVector.z);
        }

        //15/03/21 
        /// <summary>
        ///Calculates the cross product of this and another vector3
        /// </summary>
        /// <param name="otherVector"></param>
        /// <returns> Returns Cross Product vector and other vector as a new Vector3</returns>
        public  Vector3 Cross(Vector3 otherVector)
        {
            return new Vector3(y * otherVector.z - z * otherVector.y, z * otherVector.x - x *otherVector.z, x * otherVector.y - y * otherVector.x);
        }


    
        public override string ToString()
        {
            return $"({x},{y},{z})";
        }

        

    }
}
