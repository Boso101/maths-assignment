using Raylib;
using static Raylib.Raylib;
using MathClasses;
using System.Diagnostics;

namespace Project2D
{
    /// <summary>
    /// The main controller class that takes care of human input
    /// It holds a reference to a Tank Object that it calls its functions on
    /// </summary>
    public class PlayerController
    {
        public Tank player;

        public PlayerController(Tank controllingTank)
        {
            player = controllingTank;
        }

        public void HandleHumanInput(float deltatime)
        {
            if (player != null)
            {


                #region "Rotation"

                // Rotate Whole Tank
                if (IsKeyDown(KeyboardKey.KEY_A))
                {
                  
                }

                if (IsKeyDown(KeyboardKey.KEY_D))
                {
              

                }

                // Rotate Turret
                if (IsKeyDown(KeyboardKey.KEY_Q))
                {
                }

                if (IsKeyDown(KeyboardKey.KEY_E))
                {


                }

                #endregion
                #region "Movement"
                // Movement
                if (IsKeyDown(KeyboardKey.KEY_W))
                {
                    player.Move(player.GlobalTransform.Forward, deltatime);
                }

                if (IsKeyDown(KeyboardKey.KEY_S))
                {
                    player.Move(player.GlobalTransform.Backward, deltatime);

                }
                #endregion

                // Shoot
                if (IsKeyDown(KeyboardKey.KEY_SPACE))
                {
             

                }



            }
        }

      


        public void HumanShoot()
        {
           
        }

        public void ChangeTank(Tank newTank)
        {
            player = newTank;
        }





    }
}
