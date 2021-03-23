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
            Tank playerT = CreateTank("Player-1", Color.LIGHTGRAY);
          




            TeleportObjectCenter(playerT);



            player = new PlayerController(playerT);

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
            Bullet bullet = new Bullet(owner, "Bullet", owner.Color, 7f, 64f);
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

            if (ai)
            {
                // Do something to it if it's AI controlled

            }

            allObjects.Add(theTank);
            return theTank;
        }
        #endregion
    }
}
