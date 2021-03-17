using System;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        public Matrix4()
        {

            SetIdentity();


        }

        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;
            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m15 = m15;
            this.m16 = m16;
        }


        
        /// <summary>
        /// Sets matrix to identity version
        /// </summary>
        public void SetIdentity()
        {
            m1 = 1; m5 = 0; m9 = 0; m13 = 0;
            m2 = 0; m6 = 1; m10 = 0; m14 = 0;
            m3 = 0; m7 = 0; m11 = 1; m15 = 0;
            m4 = 0; m8 = 0; m12 = 0; m16 = 1;
        }



        /// <summary>
        /// Multiplies a matrix4 with a vector4
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>A new Vector3 </returns>
        public static Vector4 operator *(Matrix4 leftSide, Vector4 rightSide)
        {
            return new Vector4
                (
         leftSide.m1 * rightSide.x + leftSide.m5 * rightSide.y + leftSide.m9 * rightSide.z + leftSide.m13 * rightSide.w,
         leftSide.m2 * rightSide.x + leftSide.m6 * rightSide.y + leftSide.m10 * rightSide.z + leftSide.m14 * rightSide.w,
         leftSide.m3 * rightSide.x + leftSide.m7 * rightSide.y + leftSide.m11 * rightSide.z + leftSide.m15 * rightSide.w,
         leftSide.m4 * rightSide.x + leftSide.m8 * rightSide.y + leftSide.m12 * rightSide.z + leftSide.m16 * rightSide.w
                );



        }


        /// <summary>
        /// Matrix4 Multiplication
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>A new Matrix4 with multiplied version of parameters</returns>
        public static Matrix4 operator *(Matrix4 leftSide, Matrix4 rightSide)
        {
            return new Matrix4


                (


                );



        }


        /// <summary>
        /// Set the X Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateX(double radians)
        {
            m1 = 1; m5 = 0; m9 = 0; m13 = 0;
            m2 = 0; m6 = (float)Math.Cos(radians); m10 = (float)-Math.Sin(radians); m14 = 0;
            m3 = 0; m7 = (float)Math.Sin(radians); m11 = (float)Math.Cos(radians); m15 = 0;
            m4 = 0; m8 = 0; m12 = 0; m16 = 1;
        }

        /// <summary>
        /// Set the Y Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateY(double radians)
        {
            m1 = (float)Math.Cos(radians); m4 = 0; m7 = (float)Math.Sin(radians);
            m2 = 0; m5 = 1; m8 = 0;
            m3 = (float)-Math.Sin(radians); m6 = 0; m9 = (float)Math.Cos(radians);
        }

        /// <summary>
        /// Set the Z Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateZ(double radians)
        {
            m1 = (float)Math.Cos(radians); m4 = (float)-Math.Sin(radians); m7 = 0;
            m2 = (float)Math.Sin(radians); m5 = (float)Math.Cos(radians); m8 = 0;
            m3 = 0; m6 = 0; m9 = 1; m10 = 0;  ;
        }
    }
}
