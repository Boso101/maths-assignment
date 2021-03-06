using MathClasses;
using Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;

namespace Project2D
{
    public class Rectangle : Shape
    {

        protected int length;
        protected int width;

      public int Length { get => length; }
      public int Width { get => width; }

        public Rectangle(string name, int width, int length) : base(name)
        {
            this.length = length;
            this.width = width;

        
        }

        public MathClasses.Vector2 GetCenter()
        {
            return new MathClasses.Vector2(width / 2, length / 2);
        }

        public Rectangle(string name, Color colour, int length, int width) : base(name, colour)
        {
            this.length = length;
            this.width = width;


        }

    public void ToggleParentOriginDraw()
        {
            drawAtParentOrigin = !drawAtParentOrigin;
        }

        public override void OnDraw()
        {
            base.OnDraw();
            Raylib.Rectangle rec;
            rec = new Raylib.Rectangle((int)globalTransform.X, (int)globalTransform.Y, width, length);
            MathClasses.Vector2 center = GetCenter();

            if (!drawAtParentOrigin)
            {

                //TODO: Temporary work around for not being able to convert between the library vectors

                // Rectangle that can rotate
                DrawRectanglePro(rec, new Raylib.Vector2(center.x, center.y), globalTransform.RotationDegrees, Colour);
            }
            
            else
            {
                //Use this to draw it differently (fixes Tank Turret Barrel
                rec = new Raylib.Rectangle((int)globalTransform.X, (int)globalTransform.Y, width, length);
                DrawRectanglePro(rec, new Raylib.Vector2(parent.LocalTransform.X, parent.LocalTransform.Y), globalTransform.RotationDegrees, Colour);

            }
            //DrawRectanglePro(rec, new Raylib.Vector2(forward.x,forward.y), globalTransform.RotationDegrees, Color.RED);

        }


    }
}
