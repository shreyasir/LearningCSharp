namespace LearningCSharp.Library.Pagination
{
    internal static class Pagination
    {
        // Get data of paged value except for first and last page
        public static IQueryable<T> Page<T>(this IQueryable<T> data, int pageIndex, int pageSize)
            => data.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        //Get data of first page
        public static IQueryable<T> FirstPage<T>(this IQueryable<T> data, int pageSize)
            => data.Take(pageSize);

        //Get data of last page
        public static IQueryable<T> LastPage<T>(this IQueryable<T> data, int pageSize)
            => data.Skip(((data.Count() / pageSize) - 1) * pageSize).Take(pageSize);

        //Get Total count of page
        public static int CountOfPages<T>(this IQueryable<T> data, int pageSize)
        {
            var total = data.Count();
            return (total / pageSize) + ((total % pageSize) > 0 ? 1 : 0);
        }
    }
}