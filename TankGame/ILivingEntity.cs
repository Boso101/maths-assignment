public interface ILivingEntity
{


    bool IsAlive { get; }

    void TakeDamage(float amount);

    void Heal(float amount);
    

    void Die();

}