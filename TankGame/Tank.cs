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
    public class Tank : BaseEntity
    {
        protected float moveSpeed = 2f;


        /// <summary>
        /// Default constructor 
        /// </summary>
        public Tank() : base()
        {
          
        }


        /// <summary>
        /// Constructor with position passed
        /// </summary>
        /// <param name="position"></param>
        public Tank(Vector2 position) : base(position)
        {
      
        }



  


        /// <summary>
        /// Handles the tanks 2d Movement
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void Move(Vector2 movement, float deltaTime)
        {
            position += movement * moveSpeed * deltaTime;

            // Then move children too


            //Probably Redraw
        }

        public void Fire()
        {

        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}

