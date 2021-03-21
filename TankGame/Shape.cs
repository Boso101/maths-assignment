using Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class Shape : SceneObject
    {
        protected Color colour;
        public Shape(string name) :base(name)
        {
            colour = Color.GRAY;
        }

        public Shape(string name, Color colour) : base(name)
        {
            this.colour = colour;
        }

     
        public Color Colour { get => colour; set => colour = value; }

    }
}
