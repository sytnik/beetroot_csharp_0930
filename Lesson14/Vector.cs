namespace Lesson14;

public struct Vector : IEquatable<Vector>
{
    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    public double X { get; set; }
    public double Y { get; set; }

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double this[Dimension dimension]
    {
        get => dimension switch
        {
            Dimension.X => X,
            Dimension.Y => Y,
            _ => 0
        };
        set
        {
            switch (dimension)
            {
                case Dimension.X:
                    X = value;
                    break;
                case Dimension.Y:
                    Y = value;
                    break;
            }
        }
    }


    public bool Equals(Vector other)
        => other.X == X && other.Y == Y;

    public override bool Equals(object? obj)
    {
        var vector = (Vector) obj;
        return vector.X == X && vector.Y == Y;
    }

    public override string ToString()
        => $"Vector, X:{X}, Y:{Y}";

    public double GetLength()
        => Math.Sqrt(X * X + Y * Y);

    public static implicit operator double(Vector vector)
        => GetLength(vector);

    public static explicit operator int(Vector vector)
        => (int) GetLength(vector);

    private static double GetLength(Vector vector)
        => Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

    public static Vector operator +(Vector vector1, Vector vector2)
        => new(vector1.X + vector2.X, vector1.Y + vector2.Y);

    public static Vector operator -(Vector vector1, Vector vector2)
        => new(vector1.X - vector2.X, vector1.Y - vector2.Y);

    public static bool operator ==(Vector vector1, Vector vector2)
        => vector1.X == vector2.X && vector1.Y == vector2.Y;

    public static bool operator !=(Vector vector1, Vector vector2)
        => vector1.X != vector2.X && vector1.Y != vector2.Y;
}