using Raylib;
using static Raylib.Raylib;
using MathClasses;

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


                // Rotation
                if (IsKeyDown(KeyboardKey.KEY_A))
                {
                    player.Rotate(-(1 * deltatime));
                }

                if (IsKeyDown(KeyboardKey.KEY_D))
                {
                    player.Rotate((1 * deltatime));
                }


                // Movement
                if (IsKeyDown(KeyboardKey.KEY_W))
                {
               
                    player.Move(player.LocalTransform.Forward, deltatime);
                }

                if (IsKeyDown(KeyboardKey.KEY_S))
                {
                    player.Move(player.LocalTransform.Backward, deltatime);
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
