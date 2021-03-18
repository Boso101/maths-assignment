using Raylib;
using static Raylib.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class Circle : Shape
    {

        protected float radius;

        public Circle(string name, Color colour, float radius) : base(name, colour)
        {
            this.radius = radius;
        }

        public Circle(string name, float radius) : base(name)
        {
            this.radius = radius;
        }

        public Circle(string name) : base(name)
        {

        }




        public override void OnDraw()
        {
            DrawCircle((int)globalTransform.X, (int)globalTransform.Y, radius, colour);
        }
    }
}
