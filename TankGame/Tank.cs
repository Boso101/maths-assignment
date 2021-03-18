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
        protected float moveSpeed = 0.25f;





        protected Shape tankBase;
        protected Shape turretBase;
        protected Shape tankBarrel;

        protected Color tankColour = Color.GRAY;

        public float Speed { get => moveSpeed; }
        public SceneObject Turret { get => turretBase; }

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Tank(SceneObject world) : base()
        {


            SetupChildren();
            AddToWorld(world);
        }

        /// <summary>
        /// Constructor with name
        /// </summary>
        public Tank(SceneObject world, string name) : base(name)
        {
            SetupChildren();
            AddToWorld(world);

        }

        public Tank(SceneObject world,string name, Color colour)
        {
            tankColour = colour;
            SetupChildren();
            AddToWorld(world);

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
            this.tankBarrel = tankBarrel;

            SetupColor();

            Debug.WriteLine($"Created Tank at {globalTransform.X},{globalTransform.Y} ");
        }

        /// <summary>
        /// This function sets up the colours for all of the tanks components
        /// </summary>
        /// <param name="color"></param>
        public void SetupColor()
        {
            tankBase.Colour   = tankColour;
            turretBase.Colour = tankColour;
            tankBarrel.Colour = tankColour;

           

        }




        /// <summary>
        /// Handles the tanks 2d Movement
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void Move(MathClasses.Vector3 movement, float deltaTime)
        {
            MathClasses.Vector3 move = movement * moveSpeed * deltaTime;
            Translate(move.x,move.y);
        }


        public void HandleTurretRotation(MathClasses.Vector3 aimPos, float deltaTime)
        {
           
        }

        public void Fire()
        {
            //Create bullet at the tank shotSpot

        }


        public void AddToWorld(SceneObject world)
        {
            world.AddChild(this);
        }


   

    }
}