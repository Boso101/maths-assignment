using Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class SpriteObject : SceneObject
    {

        protected Texture2D texture = new Texture2D();
        protected Color color;


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
            texture = Raylib.Raylib.LoadTexture(fileName);
        }

        public override void OnDraw()
        {
            base.OnDraw();
            Raylib.Raylib.DrawTextureEx(texture, new Raylib.Vector2(globalTransform.X, globalTransform.Y), globalTransform.RotationDegrees, 1, color);
        }


    }

}
