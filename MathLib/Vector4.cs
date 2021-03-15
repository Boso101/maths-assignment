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

    }
}
