using System;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        // Coordinate properties
        public float X { get => m7; }
        public float Y { get => m8; }


        public Vector3 Backward
        { 
        
        get
            {
                return new Vector3(-m4, -m5, 0);
            }
        
        }

        public float RotationRadians
        {




            get
            {
                return (float)Math.Atan2(m2, m1);

            }
        }



        public float RotationDegrees
        {




            get
            {
                return (RotationRadians * (float)(180.0f/Math.PI));

            }
        }

        public Vector3 Right
        {

            get
            {
                return new Vector3(m1, m2, 0);
            }

        }

        public Vector3 Forward
        {

            get
            {
                return -1 * Backward;
            }

        }

        public Vector3 Left
        {

            get
            {
                return -1 * Right;
            }

        }


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

        /// <summary>
        /// Copy Function
        /// </summary>
        /// <param name="otherMatrix"></param>
        public void CopyFrom(Matrix3 otherMatrix)
        {
            this.m1 = otherMatrix.m1;
            this.m2 = otherMatrix.m2;
            this.m3 = otherMatrix.m3;
            this.m4 = otherMatrix.m4;
            this.m5 = otherMatrix.m5;
            this.m6 = otherMatrix.m6;
            this.m7 = otherMatrix.m7;
            this.m8 = otherMatrix.m8;
            this.m9 = otherMatrix.m9;


        }
        // These rotate functions are assuming the 
        // Matrix represents a SceneObject
        public void RotateX(double radians)
        {
            Matrix3 matrix = new Matrix3();
            matrix.SetRotateX(radians);

            //Make this matrix the result from multiplying with the rotated version
            CopyFrom(this * matrix);
        }
        public void RotateY(double radians)
        {
            Matrix3 matrix = new Matrix3();
            matrix.SetRotateY(radians);

            //Make this matrix the result from multiplying with the rotated version
            CopyFrom(this * matrix);
        }
        public void RotateZ(double radians)
        {
            Matrix3 matrix = new Matrix3();
            matrix.SetRotateZ(radians);

            //Make this matrix the result from multiplying with the rotated version
            CopyFrom(this * matrix);
        }

        /// <summary>
        /// Sets the scale of the matrix with 3 values
        /// Allows to be multiplied by other scale matrices
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetScaled(float x, float y, float z)
        {
            //Reset to identity
            SetIdentity();

            // then change coords
            m1 = x;
            m5 = y;
            m9 = z;
        }

        /// <summary>
        /// Sets the scale of the matrix with a Vector3
        /// Allows to be multiplied by other scale matrices
        /// </summary>
        /// <param name="vector"></param>
        public void SetScaled(Vector3 vector)
        {
            SetIdentity();

            m1 = vector.x;
            m5 = vector.y;
            m9 = vector.z;
        }

        // In most of these functions,
        // we multiply ourself with a identity matrix
        // which has been affected by whatever
        // in this scale function we multiply ourselves
        // by a scaled matrix3

        /// <summary>
        /// Actually scales the Scene Object using 3 values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Scale(float x, float y, float z)
        {
            Matrix3 newMatrix = new Matrix3();
            newMatrix.SetScaled(x, y, z);

            CopyFrom(this * newMatrix);
        }

        /// <summary>
        /// Actually scales the Scene Object using a Vector3
        /// </summary>
        /// <param name="scaleVector"></param>
        public void Scale(Vector3 scaleVector)
        {
            Matrix3 newMatrix = new Matrix3();
            newMatrix.SetScaled(scaleVector);

            CopyFrom(this * newMatrix);
        }

        /// <summary>
        /// Translates object to the coordinates
        /// Basically teleports
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetTranslation(float x, float y)
        {
            //SetIdentity();

            m7 = x;
            m8 = y;
        }

        /// <summary>
        /// Translates object to the coordinates
        /// Adds onto coordinatees
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Translate(float x, float y)
        {
           // SetIdentity();

            Matrix3 newMatrix = new Matrix3();
            newMatrix.SetTranslation(x,y);

            CopyFrom(this * newMatrix);
        }


        /// <summary>
        /// Translates objects via global coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void TranslateGlobal(float x, float y)
        {
            m7 += x;
            m8 += y;
        }


      
    }
}