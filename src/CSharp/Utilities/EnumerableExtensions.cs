namespace AdventOfCode2021
{
    public static class EnumerableExtensions
    {
        private static InvalidOperationException NotEnoughItemsException => new ("Collection has not enough items.");

        public static (T, T) FirstDouble<T>(this IEnumerable<T> enumerable)
        {
            var enumerator = enumerable.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw NotEnoughItemsException;
            }
            T item1 = enumerator.Current;

            if (!enumerator.MoveNext())
            {
                throw NotEnoughItemsException;
            }
            T item2 = enumerator.Current;

            return (item1, item2);
        }

        public static (T, T, T) FirstTriple<T>(this IEnumerable<T> enumerable)
        {
            var enumerator = enumerable.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw NotEnoughItemsException;
            }
            T item1 = enumerator.Current;

            if (!enumerator.MoveNext())
            {
                throw NotEnoughItemsException;
            }
            T item2 = enumerator.Current;

            if (!enumerator.MoveNext())
            {
                throw NotEnoughItemsException;
            }
            T item3 = enumerator.Current;

            return (item1, item2, item3);
        }
    }
}
