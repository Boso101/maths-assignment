using Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class Bullet : Circle
    {
        protected float moveSpeed;
        protected float damage;
        public Bullet(SceneObject world, string name, Color colour, float radius, float damage, float flySpeed) : base(name, colour, radius)
        {
            this.damage = damage;
            moveSpeed = flySpeed;




            world.AddChild(this);

        }


        public override void OnUpdate(float deltaTime)
        {
            
            MathClasses.Vector3 movement = localTransform.Forward * moveSpeed * deltaTime;
            // Move forward
            localTransform.Translate(movement.x, movement.y);

        }


    }
}
