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

        private static PlayerController player;
        readonly static SceneObject root = new SceneObject("World");
        public static List<SceneObject> toRemoveList = new List<SceneObject>();

     

       
        public void DrawPlayerHealth()
        {
            // Draw Player stats
            if (player.player != null)
            {
                Raylib.Raylib.DrawText($"Health: {player.player?.CurrentHealth}", 6, 730, 36, Color.BLACK);

            }
        }

        public  void SetupTankGame()
        {
            Tank playerT = new Tank("Player-Tank", Color.DARKGREEN, false);
            TryCreate(playerT);
            TryCreate(new Tank("Enemy 01",Color.GOLD, false, true));
            TryCreate(new Tank("Enemy 02", Color.GOLD, false, true));



            player = new PlayerController(playerT);


            // Teleport to middle
            Vector2 pos = new Vector2(Raylib.Raylib.GetScreenWidth() / 2, Raylib.Raylib.GetScreenHeight() / 2);
            playerT.Translate(pos.x, pos.y);

            root.GetChild(1).SetPosition(pos.x, 60);
            root.GetChild(2).SetPosition(pos.x+100, 60);




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

            RemoveObjects();

        }

        private void RemoveObjects()
        {

            //At the end of the root update, then go through all the objects we want removed
            foreach (SceneObject obj in toRemoveList)
            {
                root.RemoveChild(obj);
            }

            //Then Clear
            toRemoveList.Clear();
        }




        /// <summary>
        /// Called on death
        /// </summary>
        /// <param name="obj"></param>
        public static void TryRemove(SceneObject obj)
        {

            toRemoveList.Add(obj);

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
