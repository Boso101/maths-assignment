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
                    player.Rotate((1f * deltatime));
                    Debug.WriteLine("Looking Left");
                }

                if (IsKeyDown(KeyboardKey.KEY_D))
                {
                    player.Rotate(-(1f * deltatime));
                    Debug.WriteLine("Looking Right");

                }

                // Rotate Turret
                if (IsKeyDown(KeyboardKey.KEY_Q))
                {
                    player.Turret.Rotate((1f * deltatime));
                    Debug.WriteLine("Looking Left");
                }

                if (IsKeyDown(KeyboardKey.KEY_E))
                {
                    player.Turret.Rotate(-(1f * deltatime));
                    Debug.WriteLine("Looking Right");

                }

                #endregion
                #region "Movement"
                // Movement
                if (IsKeyDown(KeyboardKey.KEY_W))
                {
                    Debug.WriteLine(player.GlobalTransform.Forward);
                   player.Move(player.LocalTransform.Backward, deltatime);
                }

                if (IsKeyDown(KeyboardKey.KEY_S))
                {
                    Debug.WriteLine(player.GlobalTransform.Backward);

                    player.Move(player.LocalTransform.Forward, deltatime);
                }
                #endregion

                // Shoot
                if (IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    HumanShoot();

                }



            }
        }

        public void ChangeTurretRotation(MathClasses.Vector2 position, float deltaTime)
        {
            player.Turret.Rotate(position.x);
        }

        public void ChangeTurretRotation(Raylib.Vector2 position, float deltaTime)
        {
            player.Turret.Rotate(position.y);
        }


        public void HumanShoot()
        {
            player.Fire();
        }

        public void ChangeTank(Tank newTank)
        {
            player = newTank;
        }





    }
}
