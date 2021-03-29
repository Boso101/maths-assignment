using MathClasses;

namespace Project2D
{
    public class Tank : Sprite, ILivingEntity, IMoveable
    {
        protected float currentHealth;
        protected float movementSpeed;
        protected bool isAi;


















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