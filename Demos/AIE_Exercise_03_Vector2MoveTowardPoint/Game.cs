using MathClasses;
using Raylib_cs;

namespace AIE_Exercise_03_Vector2MoveTowardPoint
{
    class Game : IGameState
    {
        Vector2 playerPos = new Vector2(400, 225);
        Vector2 targetPos = new Vector2(500, 225);
        float speed = 10;
        public Game(Program program) : base(program)
        {

        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                targetPos = Raylib.GetMousePosition();
            }

            Vector2 dirToTarget = Vector2.Normalise(targetPos - playerPos) * speed;
            playerPos += dirToTarget;
        }

        public override void Draw()
        {
            DrawPlayer();
            DrawTarget();
        }

        public void DrawPlayer()
        {
            float radius = 10;

            // draw a circle representing the player
            Raylib.DrawCircleV(playerPos, 10, Color.RED);

            // Draw a line in the direction of movement
            Vector2 endLinePoint = playerPos + (Vector2.Normalise(targetPos - playerPos) * radius);
            Raylib.DrawLineEx(playerPos, endLinePoint, 2, Color.BLACK);
        }

        public void DrawTarget()
        {
            // draw the target
            Raylib.DrawCircleV(targetPos, 3, Color.RED);
        }
    }
}
