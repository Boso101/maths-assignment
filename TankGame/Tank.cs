using MathClasses;
using Raylib;
using System.Diagnostics;

namespace Project2D
{
    /// <summary>
    /// Main Tank Class
    /// </summary>
    /// 

    //TODO: Collisions
    public class Tank : SceneObject, ILivingEntity, IMoveable, IShooter
    {
        protected Color tankColor;

        // Some default values
        protected float currentHealth = 5f;
        protected float movementSpeed = 64f;
        protected float rotationSpeed = 2f;
        

        public float RotationSpeed { get => rotationSpeed; }

        protected bool isAi;

        protected bool rgbTank = false;
        protected float rgbChange = 0.5f;
        protected float currentTime;


        protected SpriteObject tankHull;
        protected SpriteObject tankTurret;
        protected SceneObject turretObject;


        public SpriteObject TankHull => tankHull;
        public SpriteObject TurretSprite => tankTurret;
        public SceneObject TankTurret => turretObject;


        public Color TankColor { get => tankColor; set => tankColor = value; }





        #region "Constructors"

        public Tank()
        {
            isAi = false;
            tankColor = Color.WHITE;

            SetupChildren();




        }

        // For some reason a lot of the colors don't seem to work as expected.
        public Tank(string name, Color color, bool rgbTank = false, bool isAi = false) : base(name)
        {
            this.isAi = isAi;
            this.rgbTank = rgbTank;
            tankColor = color;

            SetupChildren();


        }







        #endregion


        public void SetupChildren()
        {
            // Setup Colors
            tankHull = new SpriteObject(tankColor);
            tankTurret = new SpriteObject(tankColor);
            turretObject = new SceneObject("Turret Object");

            //Load sprites
            if (!rgbTank)
            {
                tankHull.Load("../Images/Tanks/Tank_White.png");


            }
            else
            {
                tankHull.Load("../Images/Tanks/Tank_Under.png");

            }

            tankTurret.Load("../Images/Tanks/Barrel_White.png");

            tankHull.SetPosition(-tankHull.Width / 2, -tankHull.Height / 2);

            //Add Tank Hull sprite as a child
            AddChild(tankHull);

            // Add turret sprite as a child to turret object
            turretObject.AddChild(tankTurret);

            //Offset turret
            tankTurret.SetPosition(-tankTurret.Width / 2, -23);

            // Add turret object as a child to the tank
            AddChild(turretObject);


            currentTime = rgbChange;
        }

        public override void OnDraw()
        {
            base.OnDraw();
        }

        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);
            currentTime -= deltaTime;
            
            if(isAi)
            {
                Think(deltaTime);
            }

            if (rgbTank && currentTime <= 0)
            {

                // Change Color
                Color c = new Color(Raylib.Raylib.GetRandomValue(0, 255), Raylib.Raylib.GetRandomValue(0, 255), Raylib.Raylib.GetRandomValue(0, 255), 255);
                tankHull.Color = c;
                tankTurret.Color = c;
                currentTime = rgbChange;
            }


        }



        #region "IBot"
        public bool AIControlled { get => isAi; }

        public void Think(float deltaTime)
        {
            if (!isAi) { return; }

            // AI Logic
            //Look at player
            TankTurret.Rotate(rotationSpeed * deltaTime);

        }
        #endregion

        #region "IShooter"
        public void Shoot()
        {
            // Create Bullet
            Bullet bullet = new Bullet("Bullet", TankColor);

          

           

           
            //Orientation
            bullet.CopyTransformToLocal(TankTurret.GlobalTransform);

            //Shift a little bit so it comes from top of barrel
            bullet.Translate(-6, 4);

            // Spawn in World
            TankGame.TryCreate(bullet);
            
        }
        #endregion

        #region "IMoveable"
        public float MovementSpeed => movementSpeed;


        public void Move(MathClasses.Vector3 dir, float deltaTime)
        {
            MathClasses.Vector3 movement = dir * movementSpeed * deltaTime;

            // Translation
            Translate(movement.x, movement.y);
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