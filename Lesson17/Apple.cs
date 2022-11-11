namespace Lesson17;

public class Apple
{
    public Position Position { get; set; }

    public Apple(Position position)
    {
        Position = position;
    }

    public void Render()
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.Write("🍏");
    }
}

public static class AppleExtentions
{
    public static Apple CreateApple()
    {
        var rows = 20;
        var columns = 20;
        var random = new Random();
        var top = random.Next(0, rows + 1);
        var left = random.Next(0, columns + 1);
        return new Apple(new Position(top, left));
    }
}