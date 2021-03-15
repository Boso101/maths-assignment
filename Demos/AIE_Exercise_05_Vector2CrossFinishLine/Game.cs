using MathClasses;
using Raylib_cs;

namespace AIE_Exercise_05_Vector2CrossFinishLine
{
    class Game : IGameState
    {
        Vector2 playerPos = new Vector2(400, 225);
        Vector2 playerMoveDir = new Vector2(0, 0);
        float playerMoveSpeed = 5.0f;

        Rectangle finishLine = new Rectangle(300, 100, 200, 25);
        Vector2 finishLineDir = new Vector2(0, -1);

        int lapCount = 0;

        bool wasInFinishBox = false;

        public Game(Program program) : base(program)
        {

        }

        public override void Update()
        {
            playerMoveDir.x = 0;
            playerMoveDir.y = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) playerMoveDir.x -= 1;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) playerMoveDir.x += 1;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) playerMoveDir.y -= 1;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) playerMoveDir.y += 1;

            playerMoveDir.Normalise();
            playerPos += playerMoveDir * playerMoveSpeed;

            bool isInFinishBox =
                playerPos.x >= finishLine.x && playerPos.x <= finishLine.x + finishLine.width &&
                playerPos.y >= finishLine.y && playerPos.y <= finishLine.y + finishLine.height;


            if (!isInFinishBox && wasInFinishBox)
            {
                float dot = finishLineDir.Dot(playerMoveDir);
                if (dot > 0) lapCount += 1;
                if (dot < 0) lapCount -= 1;
            }

            wasInFinishBox = isInFinishBox;

            /*
            TODO:


            check if the player is inside the finishLineRect
            
            if the player IS within the rectangle this frame, and
                was NOT in the rectangle last frame then
                    - we just entered the box
            
            if the player IS NOT within the rectangle this frame, and
                was IN the rectangle last frame then
                    - we just exeted the box
            
            Increment LapCount if we exited the finishline in correct direction
            Decrement the Lapcount if we exited the finishline in the wrong direction
            */
        }

        public override void Draw()
        {
            DrawFinishLine();
            DrawPlayer();
            DrawUI();
        }

        public void DrawUI()
        {
            Raylib.DrawText($"Lap Count: {lapCount}", 10, 10, 10, Color.BLACK);
        }

        public void DrawPlayer()
        {
            float radius = 10;

            // draw a circle representing the player
            Raylib.DrawCircleV(playerPos, 10, Color.RED);

            // Draw a line in the direction of movement
            if (playerMoveDir.Magnitude() > 0)
            {
                Vector2 endLinePoint = playerPos + (playerMoveDir * radius);
                Raylib.DrawLineEx(playerPos, endLinePoint, 2, Color.BLACK);
            }
        }

        public void DrawFinishLine()
        {
            Raylib.DrawRectangleRec(finishLine, Color.GRAY);
            Raylib.DrawLineEx(
                new Vector2(finishLine.x, finishLine.y),
                new Vector2(finishLine.x + finishLine.width, finishLine.y),
                2,
                Color.BLACK);

            Raylib.DrawLineEx(
                new Vector2(finishLine.x + finishLine.width / 2, finishLine.y),
                new Vector2(finishLine.x + finishLine.width / 2, finishLine.y - 10),
                2,
                Color.BLACK);
        }
    }
}
