﻿using MathClasses;
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





        protected Rectangle tankBase;
        protected Circle turretBase;
        protected Rectangle tankBarrel;
        protected SceneObject shotSpot;

        protected Color tankColour = Color.GRAY;

        public float Speed { get => moveSpeed; }
        public SceneObject Turret { get => turretBase; }
        public SceneObject TankBase { get => tankBase; }

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

        public Tank(string name, Color colour) :base(name)
        {
            tankColour = colour;
            SetupChildren();

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

        

            //Set it to middle of rectangle
            MathClasses.Vector2 pos = tankBase.GetCenter();
            turretBase.SetPosition(pos.x, pos.y);

            //Make Barrel end of circle
            // For now just shift it up manually
            tankBarrel.SetPosition(tankBarrel.LocalTransform.X-3, tankBarrel.LocalTransform.Y - 30);

            //Make shot spot end of the barrel
            shotSpot.SetPosition(tankBarrel.LocalTransform.X, tankBarrel.LocalTransform.Y - 1);

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
            MathClasses.Vector3 move = movement   * moveSpeed * deltaTime;
            Translate(globalTransform.X + move.x,globalTransform.Y + move.y);


        }

        public void Rotate(MathClasses.Vector3 rotation, float deltaTime)
        {
            MathClasses.Vector3 newRot = rotation * 1f * deltaTime;
            tankBase.Rotate(newRot.y);
        }


        public void HandleTurretRotation(MathClasses.Vector3 aimPos, float deltaTime)
        {
           
        }

        public void Fire()
        {
            //Create bullet at the tank shotSpot and make it move forward
           Game.CreateBullet(this, shotSpot.GetCoordinates());

            



        }

        /// <summary>
        /// Text Debugging
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);

#if DEBUG
            MathClasses.Vector3 shotCoords = shotSpot.GetCoordinates();
            DrawText("ShotSpotG", (int)shotCoords.x, (int)shotCoords.y, 14, Raylib.Color.GREEN);
            DrawText("ShotSpotL", (int)shotSpot.LocalTransform.X, (int)shotSpot.LocalTransform.Y, 14, Raylib.Color.GREEN);


            DrawText("TankBaseL", (int)tankBase.LocalTransform.X, (int)tankBase.LocalTransform.Y, 14, Raylib.Color.GREEN);
            DrawText("TankBaseG", (int)tankBase.GlobalTransform.X, (int)tankBase.GlobalTransform.Y, 14, Raylib.Color.GREEN);

            DrawText("TankTurretL", (int)turretBase.LocalTransform.X, (int)turretBase.LocalTransform.Y, 14, Raylib.Color.GREEN);
            DrawText("TankTurretG", (int)turretBase.GlobalTransform.X, (int)turretBase.GlobalTransform.Y, 14, Raylib.Color.GREEN);

#endif
        }




    }
}