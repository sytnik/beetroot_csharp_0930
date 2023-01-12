namespace Lesson35MVC.Logic
{
    public static class SortingExtensions
    {
        public static IOrderedEnumerable<T> SortByProp<T>(this IQueryable<T> query, string prop,
            bool isAsc = true) where T : class
        {
            var propInfo = typeof(T).GetProperty(prop);
            return isAsc
                ? query.AsEnumerable().OrderBy(x => propInfo.GetValue(x, null))
                : query.AsEnumerable().OrderByDescending(x => propInfo.GetValue(x, null));
        }
    }
}
