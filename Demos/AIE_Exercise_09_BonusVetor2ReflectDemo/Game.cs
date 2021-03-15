using MathClasses;
using Raylib_cs;
using System.Collections.Generic;

namespace AIE_Exercise_08_Vetor2ReflectDemo
{
    class Game : IGameState
    {
        List<Vector2> path = new List<Vector2>();

        float rayRotation = 0.0f;
        float rayLength = 300.0f;
        Vector2 mousePos = new Vector2();

        bool freeze = false;

        public Game(Program program) : base(program)
        {
            // TODO: Load Game Assets as needed
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                freeze = !freeze;

            if (!freeze && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON))
            {
                path.Add(Raylib.GetMousePosition());
            }

            if (!freeze)
                mousePos = Raylib.GetMousePosition();

            rayRotation += Raylib.GetMouseWheelMove() * 0.1f; ;

        }

        public override void Draw()
        {
            DrawPath();
            DrawRay();
            DrawUI();
        }

        public void DrawRay()
        {
            Vector2 rayDir = Vector2.CreateRotationVector(rayRotation);
            Vector2 startPos = mousePos;
            Vector2 endPos = startPos + rayDir * rayLength;

            Raylib.DrawLineV(startPos, endPos, Color.BLACK);

            // draw lines between each point
            for (int i = 1; i < path.Count; i++)
            {
                var p1 = path[i];
                var p2 = path[i - 1];
                var ip = FindIntersection(p1, p2, startPos, endPos);

                if (ip.x != float.NaN && ip.y != float.NaN)
                {
                    // Draw a dot at the intersection
                    Raylib.DrawCircleV(ip, 4, Color.RED);

                    // Draw a line for the normal
                    Vector2 normal = Vector2.Normalise(p2 - p1).GetPerpendicular();

                    if (Vector2.Dot(normal, rayDir) > 0)
                    {
                        normal *= -1;
                    }

                    Raylib.DrawLineV(ip, ip + (normal * 20), Color.RED);


                    // Draw the reflected vector
                    Vector2 reflected = Vector2.Reflect(rayDir, normal) * 100;
                    Raylib.DrawLineV(ip, ip + reflected, Color.RED);



                }

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

        public void DrawUI()
        {
            Raylib.DrawText($"Rotation: {rayRotation}", 10, 10, 10, Color.BLACK);
        }

        /// <summary>
        /// BLACK MAGIC VODO!
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="e1"></param>
        /// <param name="s2"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        Vector2 FindIntersection(Vector2 s1, Vector2 e1, Vector2 s2, Vector2 e2)
        {

            float p0_x = s1.x;
            float p0_y = s1.y;
            float p1_x = e1.x;
            float p1_y = e1.y;
            float p2_x = s2.x;
            float p2_y = s2.y;
            float p3_x = e2.x;
            float p3_y = e2.y;

            float s1_x, s1_y, s2_x, s2_y;
            s1_x = p1_x - p0_x; s1_y = p1_y - p0_y;
            s2_x = p3_x - p2_x; s2_y = p3_y - p2_y;

            float s, t;
            s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
            t = (s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {
                return new Vector2(p0_x + (t * s1_x), p0_y + (t * s1_y));
            }

            return new Vector2(float.NaN, float.NaN);
        }

    }
}
