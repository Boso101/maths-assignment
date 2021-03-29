using MathClasses;

namespace Project2D
{
    /// <summary>
    /// Main Tank Class
    /// </summary>
    public class Tank : Sprite, ILivingEntity, IMoveable, IShooter
    {
        protected float currentHealth;
        protected float movementSpeed;
        protected bool isAi;





        #region "Constructors"

        public Tank()
        {
            currentHealth = 5f;
            movementSpeed = 4f;
            isAi = false;
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


        public void Move(Vector3 dir, float deltaTime)
        {
            Vector3 movement = dir * deltaTime * movementSpeed;
            
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