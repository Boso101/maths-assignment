using MathClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    /// <summary>
    /// The Base Tank class 
    /// </summary>
    public class Tank : SceneObject
    {
        protected float moveSpeed = 2f;

        

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Tank() : base()
        {


            SetupChildren();
        }

        /// <summary>
        /// Custom Color Constructor
        /// </summary>
        public Tank(string name) : base(name)
        {
            SetupChildren();
        }

        public void SetupChildren()
        {
            AddChild(new Rectangle("TankBase", 4, 2));
            AddChild(new Circle("TankTurretCircle", 4));

            // We will need a rectangle base
            // and a circle turret for now
        }







        /// <summary>
        /// Handles the tanks 2d Movement
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void Move(Vector2 movement, float deltaTime)
        {
            Translate(movement.x, movement.y);
        }

        public void Fire()
        {

        }

        public override void OnDraw()
        {
            
        }
    }
}