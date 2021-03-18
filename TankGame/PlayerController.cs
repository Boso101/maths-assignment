using MathClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public class PlayerController
    {
        public Tank player;

        public PlayerController(Tank controllingTank)
        {
            player = controllingTank;
        }

        public void HandleHumanInput(float deltatime)
        {

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
