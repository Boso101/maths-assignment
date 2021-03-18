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
        protected float moveSpeed = 0.5f;
        protected float damage = 2f;





        protected Rectangle tankBase;
        protected Circle turretBase;
        protected Rectangle tankBarrel;
        protected SceneObject shotSpot;

        protected Color tankColour = Color.GRAY;

        public float Speed { get => moveSpeed; }
        public SceneObject Turret { get => turretBase; }
        public SceneObject TankBase { get => tankBase; }

        public SceneObject TankBarrel { get => tankBarrel; }

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

        public Tank(SceneObject world,string name, Color colour) :base(name)
        {
            tankColour = colour;
            SetupChildren();
            AddToWorld(world);

        }

        public void SetupChildren()
        {
             tankBase = new Rectangle("TankBase", 48, 28);
             turretBase = new Circle("TankTurretCircle", 8);
             tankBarrel = new Rectangle("TankBarrel", 24, 6);
            shotSpot = new SceneObject("ShotSpot");


            

            AddChild(tankBase);
            AddChild(turretBase);

            //Make Barrel a child of turret
            turretBase.AddChild(tankBarrel);

            //Make Shotspot child of turret
            turretBase.AddChild(shotSpot);

            //Init Positions
            tankBase.SetPosition(0, 0);

            //Set it to middle of rectangle
            MathClasses.Vector2 pos = tankBase.GetCenter();
            turretBase.SetPosition(pos.x, pos.y);

            //Make Barrel end of circle
            // For now just shift it up manually
            tankBarrel.SetPosition(tankBarrel.LocalTransform.X-3, tankBarrel.LocalTransform.Y - 30);

            //Make shot spot end of the barrel
            shotSpot.SetPosition(tankBarrel.LocalTransform.X, tankBarrel.LocalTransform.Y - 4);

            SetupColor();

            Debug.WriteLine($"Created Tank at {globalTransform.X},{globalTransform.Y} ");
            Debug.WriteLine("");
            Debug.WriteLine($"Hierachy{this.ToString()}");
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
            Debug.WriteLine($"Original: {GetCoordinates()}");
            MathClasses.Vector3 move = movement * deltaTime * moveSpeed;
            Translate(move.x,move.y);
            Debug.WriteLine($"New: {GetCoordinates()}");


        }


        public void HandleTurretRotation(MathClasses.Vector3 aimPos, float deltaTime)
        {
           
        }

        public void Fire()
        {
            //Create bullet at the tank shotSpot and make it move forward
            Bullet bullet = new Bullet(parent, "Bullet", tankColour, 7, damage, 1f);

            //set position to where shotspot is
            MathClasses.Vector3 coords = shotSpot.GetCoordinates();
            bullet.SetPosition(coords.x, coords.y);


        }


        public void AddToWorld(SceneObject world)
        {
            world.AddChild(this);
        }


   

    }
}