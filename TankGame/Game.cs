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

      
        
        private SceneObject world;

        /// <summary>
        /// Called every frame to draw the world and every gameobject
        /// </summary>
        public void DrawWorld()
        {
            world.Draw();
        }

       
   
        public void SetupTankGame()
        {
            world = new SceneObject("World");


            Tank firstTank = new Tank(world, "Player", Color.RED);
            Tank enemy = new Tank(world, "Enemy", Color.WHITE);


          
         
            
            
            player = new PlayerController(firstTank);

            TeleportObjectCenter(firstTank);

     
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

            // insert game logic here 
            //Input will be here using PlayerController
            player.HandleHumanInput(deltaTime);
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.ORANGE);

            DrawText(fps.ToString(), 10, 10, 14, Color.GREEN);

            // Draw world
            DrawWorld();
            EndDrawing();
        }

    }
}
