using MathClasses;
using Raylib;
using System.Diagnostics;

namespace Project2D
{
    /// <summary>
    /// Main Tank Class
    /// </summary>
    public class Tank : SceneObject, ILivingEntity, IMoveable, IShooter
    {
        protected Color tankColor;

        // Some default values
        protected float currentHealth = 5f;
        protected float movementSpeed = 4f;
        protected bool isAi;


        protected SpriteObject tankHull;
        protected SpriteObject tankTurret;


        #region "Constructors"

        public Tank()
        { 
            isAi = false;
            tankColor = Color.WHITE;

            SetupChildren();

            tankHull.Load("../Images/Tanks/Tank_White.png");
            tankTurret.Load("../Images/Tanks/Barrel_White.png");


        }

        public Tank(string name, Color color, bool isAi = false) : base(name)
        {
            this.isAi = isAi;
            tankColor = color;

            SetupChildren();

            tankHull.Load("../Images/Tanks/Tank_White.png");
            tankTurret.Load("../Images/Tanks/Barrel_White.png");
        }


        public void SetupChildren()
        {
            tankHull = new SpriteObject(tankColor);
            tankTurret = new SpriteObject(tankColor);

            AddChild(tankHull);
            AddChild(tankTurret);

            //offset Turret
            tankTurret.SetPosition(0, 24);
        }

     
       

        #endregion










        #region "IShooter"
        public void Shoot()
        {
            // Create Bullet
            SceneObject bullet = new SceneObject("Bullet");

            // Do stuff to it


            // Spawn in World
            TankGame.TryCreate(bullet);
            
        }
        #endregion

        #region "IMoveable"
        public float MovementSpeed => movementSpeed;


        public void Move(MathClasses.Vector3 dir, float deltaTime)
        {
            MathClasses.Vector3 movement = dir * deltaTime * movementSpeed;
            
            // Translation
        }
        #endregion


        #region "Living Entity"
        public bool IsAlive => currentHealth > 0;
        public float CurrentHealth => currentHealth;


        public void Die()
        {
            // Calls static function to remove from the Scene Object List
            TankGame.TryRemove(this);
        }

        public void Heal(float amount)
        {
            currentHealth += amount;
        }

      

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if(!IsAlive)
            {
                Die();
            }
        }
        #endregion
    }
}