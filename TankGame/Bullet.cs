using MathClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class Bullet : SpriteObject, IMoveable
    {
        protected float moveSpeed = 200f;

        public Bullet(string name, Raylib.Color color) : base(name, color)
        {
            Load("../Images/Bullets/bulletSilver.png");
        }
       

        public float MovementSpeed { get => moveSpeed; }

        public void Move(Vector3 dir, float deltaTime)
        {
            MathClasses.Vector3 movement = dir * moveSpeed * deltaTime;

            // Translation
            TranslateLocal(movement.x, movement.y);
        }


        public override void OnUpdate(float deltaTime)
        {
            // Fly Forward
            TranslateLocal(0, moveSpeed * deltaTime);
            CheckDespawn();
        }

        /// <summary>
        /// Should the bullet despawn
        /// </summary>
        public void CheckDespawn()
        {
            // Honestly not a fan of grabbing screen width and height on update but it'll do
            if ((globalTransform.X < 0) || (globalTransform.X > Raylib.Raylib.GetScreenWidth()) || (globalTransform.Y < 0) || (globalTransform.Y > Raylib.Raylib.GetScreenHeight()))
            {
                // Try delete/remove from game
                TankGame.TryRemove(this);

            }


        }
    }
}
