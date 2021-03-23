using Raylib;
using static Raylib.Raylib;
using System;
using System.Diagnostics;
using MathClasses;
using System.Collections.Generic;

namespace Project2D
{
    public abstract class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        protected long currentTime = 0;
        protected long lastTime = 0;
        protected float timer = 0;
        protected int fps = 1;
        protected int frames;
        protected float deltaTime = 0.005f;



        /// <summary>
        /// Called every frame to draw the world and every gameobject
        /// </summary>
        public virtual void DrawWorld()
        {
            
        }

        /// <summary>
        /// Called every frame to update the world and every gameobject
        /// </summary>
        public virtual void UpdateWorld()
        {

        }



    

        public void TeleportObjectCenter(SceneObject obj)
        {
            // Should use vars instead of hardcode
            obj.SetPosition(400, 300);
        }

        public Game()
        {




        }

        public virtual void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

       

            
        }

        public virtual void Shutdown()
        {

        }
  

        public virtual void Update()
        {
            UpdateWorld();
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


 
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.ORANGE);


            // Draw world
            DrawWorld();
            EndDrawing();
        }



      
    }
}
