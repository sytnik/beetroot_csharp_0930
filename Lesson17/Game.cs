namespace Lesson17;

public class Game
{
    public Position StartPosition = new(0, 0);
    public Direction CurrentDirection;
    public Direction NextDirection;

    public Snake _snake;
    public Apple _apple;

    public Game()
    {
        _snake = new Snake(StartPosition, 3);
        _apple = AppleExtentions.CreateApple();
        CurrentDirection = Direction.Right;
        NextDirection = Direction.Right;
    }

    public bool IsGameOver => !_snake.IsAlive;

    public void OnKeyPress(ConsoleKey key)
    {
        Direction newDirection;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                newDirection = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                newDirection = Direction.Down;
                break;
            case ConsoleKey.LeftArrow:
                newDirection = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                newDirection = Direction.Right;
                break;
            default: return;
        }

        if (newDirection == OppositeDirection(CurrentDirection))
            return;
        NextDirection = newDirection;
    }

    public Direction OppositeDirection(Direction direction) =>
        direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new Exception()
        };

    public void Render()
    {
        Console.Clear();
        _snake.Render();
        _apple.Render();
        Console.SetCursorPosition(0, 0);
    }

    public void OnTick()
    {
        if(IsGameOver) throw new Exception();
        CurrentDirection = NextDirection;
        _snake.Move(CurrentDirection);
        if (_snake.Head.Equals(_apple.Position))
        {
            _snake.Grow();
            _apple = AppleExtentions.CreateApple();
        }
    }
}