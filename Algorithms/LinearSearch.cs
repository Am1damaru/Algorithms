namespace Algorithms
{
    public static class LinearSearch
    {
        public const string NOT_FOUND = "NOT-FOUND";

        public static string BasicSearch<T>(T[] array, int amountSortedItems, T searchedElement) where T : IComparable<T>
        {
            string answer = NOT_FOUND;

            for (int index = 0; index < amountSortedItems; index++)
            {
                if (array[index].CompareTo(searchedElement) == 0)
                {
                    answer = index.ToString();
                }
            }

            return answer;
        }

        public static string BetterSearch<T>(T[] array, int amountSortedItems, T searchedElement) where T : IComparable<T>
        {
            string answer = NOT_FOUND;

            for (int index = 0; index < amountSortedItems; index++)
            {
                if (array[index].CompareTo(searchedElement) == 0)
                {
                    return index.ToString();
                }
            }

            return answer;
        }

        public static string SearchWithSentinel<T>(T[] array, int amountSortedItems, T searchedElement) where T : IComparable<T>
        {
            int indexLastElement = amountSortedItems - 1;
            var lastElement = array[indexLastElement];
            array[indexLastElement] = searchedElement;
            int index = 0;

            while (array[index].CompareTo(searchedElement) != 0)
            {
                index++;
            }

            array[indexLastElement] = lastElement;

            if ((index < indexLastElement) || (array[index].CompareTo(searchedElement) == 0))
                return index.ToString();
            return NOT_FOUND;
        }

        public static string RecursiveSearch<T>(T[] array, int amountSortedItems, int index, T searchedElement) where T : IComparable<T>
        {
            if (index >= amountSortedItems)
            {
                return NOT_FOUND;
            }
            else if (array[index].CompareTo(searchedElement) == 0)
            {
                return index.ToString();
            }
            else
            {
                return RecursiveSearch<T>(array, amountSortedItems, index + 1, searchedElement);
            }
        }
    }
}
