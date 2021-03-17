using System;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour;

        public Colour()
        {
            colour = 0;

         




        }
        public Colour(byte red, byte green, byte blue, byte alpha = 255)
        {
            // Use Setters
            SetRed(red);
            SetGreen(green);
            SetBlue(blue);
            SetAlpha(alpha);
        
        }

        // For the Getters, we had to bracket it specfically like that 
        // so that it first computes colour & bitfield then >>
        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        /// <summary>
        /// Sets new red Colour by clearing red component from bitmask and updates
        /// </summary>
        /// <param name="red"></param>
        public void SetRed(byte red)
        {
            // 00 = red byte
            // Clears the existing red component from colour bitmask
            colour &= 0x00ffffff;

            colour |= (UInt32)red << 24;
        }
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);

        }


        /// <summary>
        /// Sets new green Colour by clearing green component from bitmask and updates
        /// </summary>
        /// <param name="green"></param>
        public void SetGreen(byte green)
        {
            // 00 = green byte

            colour &= 0xff00ffff;
            colour |= ((UInt32)green << 16);

        }
        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8);

        }


        /// <summary>
        /// Sets new blue Colour by clearing blue component from bitmask and updates
        /// </summary>
        /// <param name="blue"></param>
        public void SetBlue(byte blue)
        {
            // 00 = blue byte

            colour &= 0xffff00ff;
            colour |= (UInt32)blue << 8;
        
        }
        public byte GetAlpha()
        {
            return (byte)((colour & 0x000000ff) >> 0);

        }




        /// <summary>
        /// Sets new alpha  by clearing alpha component from bitmask and updates
        /// </summary>
        /// <param name="alpha"></param>
        public void SetAlpha(byte alpha)
        {
            // 00 = alpha byte

            colour &= 0xffffff00;
            colour |= (UInt32)alpha << 0;
        }

    }
}
