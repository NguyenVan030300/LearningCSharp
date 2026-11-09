namespace HelloWorld
{
    class GameField
    {
        public int fieldWidth { get; private set; }
        public int fieldHeight { get; private set; }

        public Player player { get; private set; }
        public Vector2D food { get; private set; }
        public int score { get; private set; }

        public bool isGameOver { get; private set; } = false;
        public GameField(int width, int height)
        {
            fieldWidth = width;
            fieldHeight = height;
            score = 0;
            player = new Player(10, 10);
            food = new Vector2D(5, 10);
        }

        public void gameUpdate()
        {
            if (player.snake.First != null)
            {
                var snakeHead = player.snake.First.Value;
                var newHead = (snakeHead.x + player.currentX, snakeHead.y + player.currentY);
                if (newHead.Item1 <= 0 || newHead.Item1 >= fieldWidth - 1 ||
                    newHead.Item2 <= 0 || newHead.Item2 >= fieldHeight - 1)
                {
                    isGameOver = true;
                    return;
                }
                foreach (var body in player.snake)
                {
                    if (newHead.Item1 == body.x && newHead.Item2 == body.y)
                    {
                        isGameOver = true;
                        return;
                    }
                }
                if (newHead.Item1 == food.x && newHead.Item2 == food.y)
                {
                    Console.Beep(60, 60);
                    score += 10;
                    bool colision = false;
                    player.updateSnakeBody(food.x, food.y);

                    do
                    {
                        food = Vector2D.getNewCoordinate(fieldWidth, fieldHeight);
                        colision = false;
                        foreach (var body in player.snake)
                        {
                            if (body.x == food.x && body.y == food.y)
                            {
                                colision = true;
                                break;
                            }
                        }
                    } while (colision);
                }
                player.updateSnakeMove(newHead.Item1, newHead.Item2);
            }
            if (Console.KeyAvailable)
            {
                player.updateMovePosition();
            }
        }
    }
}
