using MathClasses;
using Raylib_cs;
using System.Collections.Generic;

namespace AIE_Exercise_04_Vector2FollowPath
{
    class Game : IGameState
    {
        List<Vector2> path = new List<Vector2>();
        Vector2 playerPos = new Vector2(400, 225);
        float speed = 4;
        public Game(Program program) : base(program)
        {

        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                path.Add(Raylib.GetMousePosition());
            }

            // TODO: Write your code here
            // --------------------------
            if (path.Count > 0)
            {
                Vector2 targetPos = path[0];
                Vector2 dirToTarget = Vector2.Normalise(targetPos - playerPos);
                playerPos += dirToTarget * 10;

                if ((targetPos - playerPos).Magnitude() < 10)
                {
                    path.RemoveAt(0);
                }
            }

            // --------------------------
        }

        public override void Draw()
        {
            DrawPlayer();
            DrawPath();
        }

        public void DrawPlayer()
        {
            float radius = 10;

            // draw a circle representing the player
            Raylib.DrawCircleV(playerPos, 10, Color.RED);

            // Draw a line in the direction of movement
            if (path.Count > 0)
            {
                Vector2 targetPos = path[0];
                Vector2 endLinePoint = playerPos + (Vector2.Normalise(targetPos - playerPos) * radius);
                Raylib.DrawLineEx(playerPos, endLinePoint, 2, Color.BLACK);
            }
        }

        public void DrawPath()
        {
            // draw lines between each point
            for (int i = 1; i < path.Count; i++)
                Raylib.DrawLineV(path[i], path[i - 1], Color.BLACK);

            // draw dot for each point
            foreach (var p in path)
                Raylib.DrawCircleV(p, 3, Color.BLACK);
        }
    }
}
