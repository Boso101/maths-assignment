

namespace Project2D
{
    public interface IShooter
    {
        float FireRate { get; }
        bool CanShoot { get; }
        void Shoot();

    }
}
