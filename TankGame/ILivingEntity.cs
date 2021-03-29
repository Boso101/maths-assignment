namespace Project2D
{

    /// <summary>
    /// Interface for a living entity, can take damage and all that
    /// </summary>
public interface ILivingEntity
{


    bool IsAlive { get; }

    float CurrentHealth { get; }

    void TakeDamage(float amount);

    void Heal(float amount);
    

    void Die();

}
}