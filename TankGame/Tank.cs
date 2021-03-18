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


        public SceneObject Turret { get => turretBase; }

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
            Rectangle tankBase = new Rectangle("TankBase", 48, 28);
            Circle turretBase = new Circle("TankTurretCircle", 8);
            Rectangle tankBarrel = new Rectangle("TankBarrel", 24, 6);

            

            AddChild(tankBase);
            AddChild(turretBase);

            //Make Barrel a child of turret
            turretBase.AddChild(tankBarrel);

            //Init Positions
            tankBase.SetPosition(0, 0);

            //Set it to middle of rectangle
            MathClasses.Vector2 pos = tankBase.GetCenter();
            turretBase.SetPosition(pos.x, pos.y);

            //Make Barrel end of circle
            // For now just shift it up manually
            tankBarrel.SetPosition(tankBarrel.LocalTransform.X-3, tankBarrel.LocalTransform.Y - 30);

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