namespace HelloWorld
{
    struct Vector2D
    {
        public int x { get; set; }
        public int y { get; set; }
        public Vector2D(int x_, int y_) => (x, y) = (x_, y_);
        public static Vector2D getNewCoordinate(int width, int height)
        {
            int newX = Random.Shared.Next(1, width - 2);
            int newY = Random.Shared.Next(1, height - 2);
            return new Vector2D(newX, newY);
        }
    }

    class Player
    {
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

        public void updateSnakeBody(int x, int y)
        {

            snake.AddFirst(new Vector2D(x, y));
        }

        public void updateSnakeMove(int x, int y)
        {
            snake.AddFirst(new Vector2D(x, y));
            snake.RemoveLast();
        }

        public void updateMovePosition()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentY != 1) { currentX = 0; currentY = -1; }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentY != -1) { currentX = 0; currentY = 1; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentX != 1) { currentX = -1; currentY = 0; }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentX != -1) { currentX = 1; currentY = 0; }
                    break;
            }
        }
    }

}
