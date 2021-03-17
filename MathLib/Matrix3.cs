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
                rightSide.x * leftSide.m1 + rightSide.y * leftSide.m4 + rightSide.z * leftSide.m7,
                rightSide.x * leftSide.m2 + rightSide.y * leftSide.m5 + rightSide.z * leftSide.m8,
                rightSide.x * leftSide.m3 + rightSide.y * leftSide.m6 + rightSide.z * leftSide.m9



                );



        }


        /// <summary>
        /// Set the X Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateX(float radians)
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        /// <summary>
        /// Set the Y Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateY(float radians)
        {

        }

        /// <summary>
        /// Set the Z Rotation
        /// </summary>
        /// <param name="radians"></param>
        public void SetRotateZ(float radians)
        {

        }


    }
}