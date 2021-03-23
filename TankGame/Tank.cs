using MathClasses;
using Raylib;
using static Raylib.Raylib;
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
        protected float moveSpeed = 64f;
        protected float damage = 2f;

        float radiansPerSecRotation = 1f;



        protected Rectangle tankHull;
        protected Circle turretBase;
        protected Rectangle tankBarrel;
        protected SceneObject shotSpot;

        protected Color tankColour = Color.GRAY;

        public float Speed { get => moveSpeed; }
        public SceneObject Turret { get => turretBase; }
        public SceneObject TankBase { get => tankHull; }

        public SceneObject TankBarrel { get => tankBarrel; }

        public float Damage { get => damage; }

        public Color Color { get => tankColour; }

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Tank() : base()
        {


            SetupChildren();

        }

        /// <summary>
        /// Constructor with name
        /// </summary>
        public Tank(string name) : base(name)
        {
            SetupChildren();

        }

        public Tank(string name, Color colour) : base(name)
        {
            tankColour = colour;
            SetupChildren();

        }

        public void SetupChildren()
        {
            tankHull = new Rectangle("TankHull", 48, 28);

            turretBase = new Circle("TankTurretCircle", 8);
            tankBarrel = new Rectangle("TankBarrel", 24, 6);
            shotSpot = new SceneObject("ShotSpot");




            AddChild(tankHull);
          


            //Make Turret child of hull
            tankHull.AddChild(turretBase);
            
            //Make Barrel a child of turret
            turretBase.AddChild(tankBarrel);

            //Make Shotspot child of turret
            turretBase.AddChild(shotSpot);


            //Set it to middle of rectangle
            turretBase.SetPosition(0,0);

            //Make Barrel end of circle
            // For now just shift it up manually
            tankBarrel.SetPosition(0,  -20);

            //Make shot spot end of the barrel
            shotSpot.SetPosition(0, tankBarrel.LocalTransform.Y - 1);

            tankHull.SetPosition(0, 0);

            SetupColor();

            Debug.WriteLine($"Created Tank at {globalTransform.X},{globalTransform.Y} ");
            Debug.WriteLine("");
           



        }

        /// <summary>
        /// This function sets up the colours for all of the tanks components
        /// </summary>
        /// <param name="color"></param>
        public void SetupColor()
        {
            tankHull.Colour = tankColour;


            //  make turretBase darker
            turretBase.Colour = new Color(tankColour.r - 40, tankColour.g - 40, tankColour.b - 40,255);
            tankBarrel.Colour = turretBase.Colour;



        }




        /// <summary>
        /// Handles the tanks 2d Movement
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void Move(MathClasses.Vector3 movement, float deltaTime)
        {

            MathClasses.Vector3 move = movement * moveSpeed * deltaTime;
            Translate(globalTransform.X + move.x, globalTransform.Y + move.y);

        }

        public void Rotate(SceneObject target, float deltaTime)
        {
            float newRot =  globalTransform.RotationDegrees * deltaTime;
            target.Rotate(newRot);
        }


        public void HandleTurretRotation(MathClasses.Vector3 aimPos, float deltaTime)
        {

        }

        public void Fire()
        {
            //Create bullet at the tank shotSpot and make it move forward
            TankGame.CreateBullet(this, shotSpot.GetCoordinates());





        }


    }
}