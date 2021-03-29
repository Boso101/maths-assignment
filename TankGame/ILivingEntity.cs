public interface ILivingEntity
{


    bool IsAlive { get; }

    float CurrentHealth { get; }

    void TakeDamage(float amount);

    void Heal(float amount);
    

    void Die();

}