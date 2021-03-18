using static Raylib.Raylib;

namespace Project2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            InitWindow(800, 600, "Hello World");

            game.Init();

            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();

            CloseWindow();
        }
    }
}
