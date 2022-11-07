namespace Lesson15;

public static class CollectionExtensions
{
    public static string GetFormattedStringFromList<T>
        (this IEnumerable<T> collection)
        => $"Generic output: \r\n{string.Join(", ", collection)}";
}

// public static class MathExtensions
// {
//     public static T GetFormulaResult<T>(T value1, T value2) where T : struct
//     {
//         T result = 0;
//         return value1 value2
//     }
// }