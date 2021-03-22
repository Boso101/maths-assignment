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
        protected SceneObject owner;
        protected float moveSpeed;
        protected float damage;
        public Bullet(Tank owner, string name, Color colour, float radius, float flySpeed) : base(name, colour, radius)
        {
            this.owner = owner;
            this.damage = owner.Damage;
            moveSpeed = flySpeed;







   

        }


        public override void OnUpdate(float deltaTime)
        {
            
            MathClasses.Vector3 movement = globalTransform.Forward * deltaTime * moveSpeed;
            // Move forward
            localTransform.Translate(0, movement.y + localTransform.Y);

        }


    }
}
