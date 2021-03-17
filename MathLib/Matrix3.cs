﻿using System;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3()
        {
            SetIdentity();


        }

        public Matrix3(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9)
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
        }

        /// <summary>
        /// Sets the matrix to the identity version
        /// </summary>
        public void SetIdentity()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;

        }

        /// <summary>
        /// Matrix3 Multiplication
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>A new Matrix3 with multiplied version of parameters</returns>
        public static Matrix3 operator *(Matrix3 leftSide, Matrix3 rightSide)
        {
            return new Matrix3
                
                
                (
                leftSide.GetRow(1).Dot(rightSide.GetColumn(1)),
                leftSide.GetRow(2).Dot(rightSide.GetColumn(1)),
                leftSide.GetRow(3).Dot(rightSide.GetColumn(1)),

                leftSide.GetRow(1).Dot(rightSide.GetColumn(2)),
                leftSide.GetRow(2).Dot(rightSide.GetColumn(2)),
                leftSide.GetRow(3).Dot(rightSide.GetColumn(2)),

                 leftSide.GetRow(1).Dot(rightSide.GetColumn(3)),
                leftSide.GetRow(2).Dot(rightSide.GetColumn(3)),
                leftSide.GetRow(3).Dot(rightSide.GetColumn(3))



                );
       
         
        
        }

        /// <summary>
        /// Multiplies a matrix3 with a vector3
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        /// <returns>A new Vector3 </returns>
        public static Vector3 operator *(Matrix3 leftSide, Vector3 rightSide)
        {
            return new Vector3
                (
                leftSide.GetRow(1).Dot(rightSide),
                leftSide.GetRow(2).Dot(rightSide),
                leftSide.GetRow(3).Dot(rightSide)



                );



        }


        /// <summary>
        /// Set the X Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateX(double radians)
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = (float)Math.Cos(radians); m8 = (float)-Math.Sin(radians);
            m3 = 0; m6 = (float)Math.Sin(radians); m9 = (float)Math.Cos(radians);
        }

        /// <summary>
        /// Set the Y Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateY(double radians)
        {
            m1 = (float)Math.Cos(radians); m4 = 0; m7 = (float)Math.Sin(radians);
            m2 = 0; m5 = 1; m8 = 0;
            m3 =(float)-Math.Sin(radians); m6 = 0; m9 = (float)Math.Cos(radians);
        }

        /// <summary>
        /// Set the Z Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateZ(double radians)
        {
            m1 = (float)Math.Cos(radians); m4 = (float)-Math.Sin(radians); m7 = 0;
            m2 = (float)Math.Sin(radians); m5 = (float)Math.Cos(radians); m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }


        /// <summary>
        /// Helper Method to grab row data from Matrix
        /// </summary>
        /// <param name="rowNumb"></param>
        public Vector3 GetRow(int rowNumb)
        {

            switch (rowNumb)
            {
                case 1:
                    return new Vector3(m1, m4, m7);

                case 2:
                    return new Vector3(m2, m5, m8);


                case 3:
                    return new Vector3(m3, m6, m9);

                default:
                    // bad number
                    return null;

            }



        }


        /// <summary>
        /// Helper Method to grab column data from Matrix
        /// </summary>
        /// <param name="columnNumb"></param>
        public Vector3 GetColumn(int columnNumb)
        {

            switch (columnNumb)
            {
                case 1:
                    return new Vector3(m1, m2, m3);

                case 2:
                    return new Vector3(m4,m5,m6);

                case 3:
                    return new Vector3(m7,m8,m9);

  

                default:
                    // bad number
                    return null;


            }


        }


    }
}