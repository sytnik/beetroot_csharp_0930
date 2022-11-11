namespace Lesson17;

public struct Position
{
    public int Top { get; set; }
    public int Left { get; set; }

    public Position(int top, int left)
    {
        Top = top;
        Left = left;
    }

    public Position RightBy(int n) => new(Top, Left + n);
    public Position DownBy(int n) => new(Top + n, Left);
}