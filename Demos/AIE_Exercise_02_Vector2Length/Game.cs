using MathClasses;
using Raylib_cs;
using System.Collections.Generic;

namespace AIE_Exercise_01_Vector2Length
{
    class Game : IGameState
    {
        float totalLength = 0.0f;
        List<Vector2> points = new List<Vector2>();

        public Game(Program program) : base(program)
        {

        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Vector2 mousePos = Raylib.GetMousePosition();
                points.Add(mousePos);
            }

            // TODO: Calculate the total length from each point
            // in the list to the next point in the list
            totalLength = CalculatePointsLength();
        }

        public override void Draw()
        {
            // draw lines between each point
            for (int i = 1; i < points.Count; i++)
                Raylib.DrawLineV(points[i], points[i - 1], Color.BLACK);

            // draw dot for each point
            foreach (var p in points)
                Raylib.DrawCircleV(p, 3, Color.BLACK);

            // Draw Information about the path
            Raylib.DrawText($"NumPoints: {points.Count}", 10, 10, 10, Color.BLACK);
            Raylib.DrawText($"Length: {totalLength}", 10, 30, 10, Color.BLACK);
        }

        float CalculatePointsLength()
        {
            float total = 0;
            for (int i = 1; i < points.Count; i++)
                total += (points[i] - points[i - 1]).Magnitude();

            return total;
        }
    }
}
