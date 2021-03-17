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
