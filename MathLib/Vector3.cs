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
        /// <returns></returns>
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
        /// <returns></returns>
        public static Vector3 operator *(Vector3 leftSide, float multiplier)
        {
            return new Vector3(leftSide.x*multiplier, leftSide.y * multiplier, leftSide.z * multiplier);
        }


        //15/03/21 
        /// <summary>
        /// Vector3 Multiplier Function
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static Vector3 operator *(float multiplier, Vector3 rightSide)
        {
            return new Vector3(rightSide.x * multiplier, rightSide.y * multiplier, rightSide.z * multiplier);
        }


        //15/03/21 
        /// <summary>
        /// Vector3 Subtraction Function
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 leftSide, Vector3 rightSide)
        {
            return new Vector3(leftSide.x - rightSide.x, leftSide.y - leftSide.y, leftSide.z - rightSide.z);
        }

        //15/03/21 
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


        //15/03/21 
        /// <summary>
        /// Vector3 Vector Transformation With Matrix3
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static Vector3 operator *(Matrix3 leftSide, Vector3 rightSide)
        {
            return new Vector3();
        }


        //15/03/21 
        /// <summary>
        ///Returns Dot of the leftSide and rightSide Vec as float
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns></returns>
        public static float Dot(Vector3 leftSide, Vector3 rightSide)
        {
            return (leftSide.x * rightSide.x) + (leftSide.y * rightSide.y) + (leftSide.z * rightSide.z);
        }


       


   
        /// <summary>
        /// Calculate the magnitude of this instance of a Vector3
        /// </summary>
        /// <returns>The magnitude of this Vector 3 </returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z*z);
        }

        /// <summary>
        /// Normalises this instance of a Vector3.
        /// </summary>
        public void Normalise()
        {
            float length = Magnitude();
            
            if (length > 0)
            {
                x /= length;
                y /= length;
                z /= length;
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
        /// <returns> Returns Cross Product vector and other vector as a float </returns>
        public static float Cross(Vector3 otherVector)
        {
            //TODO: Implement this
            return 0;
        }


    }
}
