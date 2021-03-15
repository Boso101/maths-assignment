using Raylib_cs;

namespace AIE_Exercise_06_CircleCircleOverlap
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Hello World";

        IGameState currentGameState;
        IGameState pendingGameState;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        public void ChangeGameState(IGameState newState)
        {
            pendingGameState = newState;
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            Load();

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void Load()
        {
            ChangeGameState(new Game(this));
        }

        void Update()
        {

            if (pendingGameState != null)
            {
                currentGameState = pendingGameState;
                pendingGameState = null;
            }

            currentGameState.Update();
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            currentGameState.Draw();

            Raylib.EndDrawing();
        }
    }
}
