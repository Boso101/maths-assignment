using MathClasses;
using Raylib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        protected SceneObject tankBase;
        protected SceneObject turretBase;

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
            SceneObject tankBase = new Rectangle("TankBase", 48, 28);
            SceneObject turretBase = new Circle("TankTurretCircle", 8);

            AddChild(tankBase);
            AddChild(turretBase);

            // then make easy references to this information
            this.tankBase = tankBase;
            this.turretBase = turretBase;

            Debug.WriteLine($"Created Tank at {globalTransform.X},{globalTransform.Y} ");
        }







        /// <summary>
        /// Handles the tanks 2d Movement
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void Move(MathClasses.Vector3 movement, float deltaTime)
        {
            Translate(movement.x, movement.y);
        }


        public void HandleTurretRotation(MathClasses.Vector3 aimPos, float deltaTime)
        {
           
        }

        public void Fire()
        {
            //Create bullet at the tank shotSpot

        }

       
    }
}