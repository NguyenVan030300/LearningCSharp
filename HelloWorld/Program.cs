using System.Text;

internal class Program
{
    struct Vector2D {
        public int x { get; set; }
        public int y { get; set; }
        public Vector2D(int x_, int y_) => (x, y) = (x_, y_);
        public void getNewCoordinate(int width, int height)
        {
            Random random = new Random();
            x = random.Next(1, width - 2);
            y = random.Next(1, height - 2);
        }
    }

    class Player {
        public LinkedList<Vector2D> snake { get; private set; }
        public int currentX { get; private set; }
        public int currentY { get; private set; }

        public Player(int x, int y)
        {
            snake = new LinkedList<Vector2D>(new[] {
                    new Vector2D(x    , y),
                    new Vector2D(x + 1, y),
                    new Vector2D(x + 2, y)
                 });
            currentX = -1;
            currentY = 0;
        }

        public void updateSnakeBody(int x, int y) {

            snake.AddFirst(new Vector2D(x, y));
        }

        public void updateSnakeMove(int x, int y) {
            snake.AddFirst(new Vector2D(x, y));
            snake.RemoveLast();
        }

        public void updateMovePosition() {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentY != -1) { currentX = 0; currentY = -1; }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentY != 1) { currentX = 0; currentY = 1; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentX != -1) { currentX = -1; currentY = 0; }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentX != 1) { currentX = 1; currentY = 0; }
                    break;
            }
        }
    }

    class GameField {
        public int fieldWidth { get; private set; }
        public int fieldHeight { get; private set; }

        Player player = new Player(10, 10);
        Vector2D food = new Vector2D(5, 10);

        public bool isGameOver = false;
        public GameField(int width, int height) => (fieldWidth, fieldHeight) = (width, height);

        public void gameUpdate() {
            if (player.snake.First != null) {
                var snakeHead = player.snake.First.Value;
                var newHead = (snakeHead.x + player.currentX, snakeHead.y + player.currentY);
                if (newHead.Item1 <= 0 || newHead.Item1 >= fieldWidth - 1 || newHead.Item2 <= 0 || newHead.Item2 >= fieldHeight - 1) {
                    isGameOver = true;
                    return;
                }
                foreach (var body in player.snake)
                {
                    if (newHead.Item1 == body.x && newHead.Item2 == body.y) {
                        isGameOver = true;
                        return;
                    }
                }
                if (snakeHead.x == food.x && snakeHead.y == food.y) {
                    bool colision = false;
                    player.updateSnakeBody(food.x, food.y);

                    do
                    {
                        food.getNewCoordinate(fieldWidth, fieldHeight);
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

        public void drawField() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < fieldHeight; ++i) {
                for (int y = 0; y < fieldWidth; ++y) {
                    if (y == 0 || y == fieldWidth - 1 || i == 0 || i == fieldHeight - 1)
                    {
                        sb.Append("#");
                    }
                    else if (food.x == y && food.y == i) {
                        sb.Append("*");
                    }
                    else
                    {
                        bool isBody = false;
                        foreach (var body in player.snake)
                        {
                            if (body.x == y && body.y == i) {
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
        }
    }

    private static void Main(string[] args)
    {
        GameField gameField = new GameField(20, 20);
        Console.Clear();
        Console.CursorVisible = false;

        while (!gameField.isGameOver)
        {
            Console.SetCursorPosition(0, 0);
            gameField.drawField();
            gameField.gameUpdate();
            Thread.Sleep(100);
        }
    }
}