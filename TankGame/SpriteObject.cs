using Raylib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class SpriteObject : SceneObject
    {

        protected Texture2D texture;
        protected Color color;

        public Color Color { get => color; set => color = value; }


        public SpriteObject(Color color)
        {
            this.color = color;
        }

        public SpriteObject(string name, Color c) : base(name)
        {
            color = c;

        }

        public float Width { get => texture.width; }


        public float Height { get => texture.height; }


        public void Load(string fileName)
        {
            if (fileName != "")
            {
             

                texture = Raylib.Raylib.LoadTexture(fileName);
            }

            if (texture.width == 0 || texture.height == 0)
            {
                // Error so load the placeHolder
                texture = Raylib.Raylib.LoadTexture("../Images/Error/Error.png");
                Debug.WriteLine("Could not find " + fileName);
                
            }
        }

        public override void OnDraw()
        {
            base.OnDraw();
            Raylib.Raylib.DrawTextureEx(texture, new Raylib.Vector2(globalTransform.X, globalTransform.Y), globalTransform.RotationDegrees, 1, color);
        }


    }

}
