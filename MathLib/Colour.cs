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

        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            
        }

        public Colour(uint colour)
        {
            this.colour = colour;
        }
    }
}
