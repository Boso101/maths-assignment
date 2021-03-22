using Raylib;
using System;
using System.Diagnostics;
using static Raylib.Raylib;
using MathClasses;
using System.Collections.Generic;

namespace Project2D
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        private PlayerController player;



        private static List<SceneObject> allObjects;

        /// <summary>
        /// Called every frame to draw the world and every gameobject
        /// </summary>
        public void DrawWorld()
        {
            foreach(SceneObject obj in allObjects)
            {
                obj.Update(deltaTime);
                obj.Draw();
            }
        }

       
   
        public void SetupTankGame()
        {


            Tank playerT = CreateTank("Player-1", Color.SKYBLUE);




           // TeleportObjectCenter(playerT);

            player = new PlayerController(playerT);




     
        }

        public void TeleportObjectCenter(SceneObject obj)
        {
            // Should use vars instead of hardcode
            obj.SetPosition(400, 300);
        }

        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            allObjects = new List<SceneObject>();
            SetupTankGame();

            
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

           
            //Input will be here using PlayerController
            player.HandleHumanInput(deltaTime);
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.ORANGE);

            DrawText(player.player.GetCoordinates().ToString(), 40, 40, 14, Color.GREEN);

            // Draw world
            DrawWorld();
            EndDrawing();
        }



        #region "Spawn Related"
        // These method are so that when things are created, they are automatically added to the Object List

        /// <summary>
        /// Construct a bullet
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="spawnPosition"></param>
        /// <returns> The bullet </returns>
        public static Bullet CreateBullet(Tank owner, MathClasses.Vector3 spawnPosition)
        {
            Bullet bullet = new Bullet(owner, "Bullet", owner.Color, 7f, 1f);
            bullet.SetPosition(spawnPosition.x, spawnPosition.y);
            allObjects.Add(bullet);
            return bullet;
        }

        /// <summary>
        /// Construct a Tank
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tankColor"></param>
        /// <returns> a Tank </returns>
        public static Tank CreateTank(string name, Color tankColor, bool ai = false)
        {
            Tank theTank = new Tank(name, tankColor);
            
            if(ai)
            {
                // Do something to it if it's AI controlled

            }

            allObjects.Add(theTank);
            return theTank;
        }
        #endregion
    }
}
