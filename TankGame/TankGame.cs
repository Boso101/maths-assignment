using Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
   public class TankGame : Game
    {

        private PlayerController player;
        readonly static SceneObject root = new SceneObject("World");

     

        public override void DrawWorld()
        {
            base.DrawWorld();

            DrawPlayerHealth();


            root.Draw();
        }

        public override void UpdateWorld()
        {
            base.UpdateWorld();
           

            root.Update(deltaTime);
        }

        public void DrawPlayerHealth()
        {
            // Draw Player stats
            if (player.player != null)
            {
                Raylib.Raylib.DrawText($"Health: {player?.player.CurrentHealth}", 0, 0, 24, Color.RED);

            }
        }

        public  void SetupTankGame()
        {
            Tank playerT = new Tank("Player-Tank", Color.PINK);
            TryCreate(playerT);
          
            player = new PlayerController(playerT);


            // Teleport to middle
            Vector2 pos = new Vector2(Raylib.Raylib.GetScreenWidth() / 2, Raylib.Raylib.GetScreenHeight() / 2);
            playerT.Translate(pos.x, pos.y);





        }

        public override void Init()
        {
            base.Init();
            SetupTankGame();
        }

        public override void Update()
        {
            
           


            base.Update();


           
        

            //Input will be here using PlayerController
            player.HandleHumanInput(deltaTime);

        }


        public void ChangeTankColor()
        {
            player.player.TankColor = new Color(Raylib.Raylib.GetRandomValue(0, 255), Raylib.Raylib.GetRandomValue(0, 255), Raylib.Raylib.GetRandomValue(0, 255), 255);
            player.player.TankHull.Color = player.player.TankColor;
            player.player.TankTurret.Color = player.player.TankColor;
        }
















        /// <summary>
        /// Called on death
        /// </summary>
        /// <param name="obj"></param>
        public static void TryRemove(SceneObject obj)
        {
            root.RemoveChild(obj);
        }

        /// <summary>
        ///Used to spawn
        /// </summary>
        /// <param name="obj"></param>
        public static void TryCreate(SceneObject obj)
        {
            root.AddChild(obj);
        }
    }
}
