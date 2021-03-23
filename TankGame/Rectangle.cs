﻿using MathClasses;
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

        public Rectangle(string name, int length, int width) : base(name)
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

    

        public override void OnDraw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle((int)globalTransform.X, (int)globalTransform.Y, width, length);
            base.OnDraw();

            DrawRectangle((int)rec.x, (int)rec.y, (int)rec.width, (int)rec.height, Colour);
            DrawRectangleLines((int)globalTransform.X, (int)globalTransform.Y, width, length, Color.BLACK);
        }

        
    }
}
