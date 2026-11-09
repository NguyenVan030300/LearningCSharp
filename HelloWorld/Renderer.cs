using System.Text;

namespace HelloWorld
{
    class ConsoleRenderer
    {
        public static void drawField(GameField gameField)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gameField.fieldHeight; ++i)
            {
                for (int y = 0; y < gameField.fieldWidth; ++y)
                {
                    if (y == 0 || y == gameField.fieldWidth - 1 || i == 0 || i == gameField.fieldHeight - 1)
                    {
                        sb.Append("#");
                    }
                    else if (gameField.food.x == y && gameField.food.y == i)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        bool isBody = false;
                        foreach (var body in gameField.player.snake)
                        {
                            if (body.x == y && body.y == i)
                            {
                                isBody = true;
                                break;
                            }
                        }
                        if (isBody == true)
                        {
                            sb.Append("0");
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }
                }
                sb.Append("\n");
            }
            Console.Write(sb);
            Console.SetCursorPosition(gameField.fieldWidth + 5, 0);
            Console.Write($"Current score = {gameField.score}");
        }
    }
}
