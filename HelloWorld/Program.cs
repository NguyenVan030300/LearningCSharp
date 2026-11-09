using HelloWorld;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        GameField gameField = new GameField(20, 20);
        Console.Clear();
        Console.CursorVisible = false;

        int gameSpeed = 100;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        long lastUpdateTicks = stopwatch.ElapsedMilliseconds;

        while (!gameField.isGameOver)
        {
            Console.SetCursorPosition(0, 0);
            ConsoleRenderer.drawField(gameField);

            long currentTicks = stopwatch.ElapsedMilliseconds;
            long elapsed = currentTicks - lastUpdateTicks;

            if (elapsed >= gameSpeed)
            {
                gameField.gameUpdate();
                lastUpdateTicks = currentTicks;
            }
            Thread.Sleep(5);
        }

        Console.Clear();
        Console.WriteLine("Game Over");
    }
}