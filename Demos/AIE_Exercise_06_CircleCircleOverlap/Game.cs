using MathClasses;
using Raylib_cs;
using System;
using System.Collections.Generic;

namespace AIE_Exercise_06_CircleCircleOverlap
{

    class Circle
    {
        public Vector2 position = new Vector2();
        public Vector2 direction = new Vector2(0, 0);
        public float radius = 50.0f;
        public Color color = new Color(0, 0, 0, 128);
    }

    class Game : IGameState
    {
        Random rand = new Random();
        List<Circle> circles = new List<Circle>();

        public Game(Program program) : base(program)
        {

        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Vector2 mousePos = Raylib.GetMousePosition();
                circles.Add(new Circle()
                {
                    position = mousePos,
                    radius = rand.Next(20, 50),
                    direction = Vector2.Normalise(new Vector2(
                        (float)rand.NextDouble() * 2.0f - 1.0f,
                        (float)rand.NextDouble() * 2.0f - 1.0f))
                });
            }

            foreach (var circle in circles)
            {
                circle.position += circle.direction;
                CircleWallBounce(circle);
            }

            UpdateCirclesOverlap();

            // TODO:
            // 1. Add code to bounce each circle off the walls of the screen
            // 2. Add code to detect if a circle has overlapped with another circle
            //      if overlapping, draw circle red = new Color(255, 0, 0, 128);
            //      otherwise, draw circle black = new Color(0, 0, 0, 128)

        }

        void UpdateCirclesOverlap()
        {
            Color red = new Color(255, 0, 0, 128);
            Color black = new Color(0, 0, 0, 128);

            // reset all circle colors to black (not overlapping)
            foreach (var circle in circles)
                circle.color = black;

            // check all circles against all other circles
            // change to red if they are overlapping.
            for (int i = 0; i < circles.Count; i++)
            {
                for (int j = i + 1; j < circles.Count; j++)
                {
                    var c1 = circles[i];
                    var c2 = circles[j];
                    if (Vector2.Distance(c1.position, c2.position) < c1.radius + c2.radius)
                    {
                        c1.color = red;
                        c2.color = red;
                    }
                }
            }
        }

        public void CircleWallBounce(Circle circle)
        {
            float left = 0 + circle.radius;
            float right = program.windowWidth - circle.radius;
            float top = 0 + circle.radius;
            float bottom = program.windowHeight - circle.radius;

            float xPos = circle.position.x;
            float yPos = circle.position.y;

            if (xPos < left || xPos > right)
                circle.direction.x = -circle.direction.x;

            if (yPos < top || yPos > bottom)
                circle.direction.y = -circle.direction.y;
        }

        public override void Draw()
        {
            DrawCircles();
        }

        void DrawCircles()
        {

            foreach (var circle in circles)
            {
                Raylib.DrawCircleV(circle.position, circle.radius, circle.color);
            }
        }
    }
}
