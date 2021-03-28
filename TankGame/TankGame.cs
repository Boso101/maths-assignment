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
        private static List<SceneObject> allObjects;

        public override void DrawWorld()
        {
            base.DrawWorld();
            
            // draw each scene object
            foreach (SceneObject obj in allObjects)
            {
                obj.Draw();
            }
        }

        public override void UpdateWorld()
        {
            base.UpdateWorld();
            // update each scene object
            foreach (SceneObject obj in allObjects)
            {
                obj.Update(deltaTime);
            }
        }

        public  void SetupTankGame()
        {
          
            player = new PlayerController(null);







        }

        public override void Init()
        {
            base.Init();
            allObjects = new List<SceneObject>();
            SetupTankGame();
        }

        public override void Update()
        {
            base.Update();
            
            
            //Input will be here using PlayerController
            player.HandleHumanInput(deltaTime);
        }
















        /// <summary>
        /// Called on death
        /// </summary>
        /// <param name="obj"></param>
        public static void TryRemove(SceneObject obj)
        {
            allObjects.Remove(obj);
        }
    }
}
