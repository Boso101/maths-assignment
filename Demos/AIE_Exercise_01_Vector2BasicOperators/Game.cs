using MathClasses;
using Raylib_cs;

namespace AIE_Exercise_01_Vectors
{
    class Game : IGameState
    {
        // Use MathLib.Vector2 class
        Vector2 playerPos = new Vector2();

        public Game(Program program) : base(program)
        {
        }

        public override void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                // Implicit conversion woking for
                // System.Numerics.Vector2 to MathLib.Vector2
                playerPos = Raylib.GetMousePosition();
            }

            float length = 10;
            Vector2 right = length * new Vector2(1, 0);
            Vector2 down = new Vector2(0, 1) * length;

            // Demo of .Add method
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
                playerPos = Vector2.Add(playerPos, right);

            // Demo of .Sub method
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
                playerPos = Vector2.Sub(playerPos, right);

            // Demo of + operator
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                playerPos += down;

            // Demo of - operator
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                playerPos -= down;

        }

        public override void Draw()
        {
            // Implicit conversion woking for
            // MathLib.Vector2 to System.Numerics.Vector2
            Raylib.DrawCircleV(playerPos, 3, Color.BLACK);

            Raylib.DrawText("Press Arrow Keys to move", 10, 10, 10, Color.BLACK);
            Raylib.DrawText("Press Left mouse button", 10, 30, 10, Color.BLACK);
        }
    }
}
