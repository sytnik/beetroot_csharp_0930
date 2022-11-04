namespace Lesson14;

public static class CollectionExtensions
{
    public static string GetFormattedStringFromList<T>
        (this IEnumerable<T> collection)
        => $"Generic output: \r\n{string.Join(", ", collection)}";
}