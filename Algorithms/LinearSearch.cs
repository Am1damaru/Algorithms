namespace Algorithms
{
    public static class LinearSearch
    {
        public const string NOT_FOUND = "NOT-FOUND";

        public static string BasicSearch<T>(T[] array, int countElements, T searchedElement) where T : IComparable<T>
        {
            string answer = NOT_FOUND;

            for (int index = 0; index < countElements; index++)
            {
                if (array[index].CompareTo(searchedElement) == 0)
                {
                    answer = index.ToString();
                }
            }

            return answer;
        }

        public static string BetterSearch<T>(T[] array, int countElements, T searchedElement) where T : IComparable<T>
        {
            string answer = NOT_FOUND;

            for (int index = 0; index < countElements; index++)
            {
                if (array[index].CompareTo(searchedElement) == 0)
                {
                    return answer = index.ToString();
                }
            }

            return answer;
        }

        public static string SearchWithSentinel<T>(T[] array, int countElements, T searchedElement) where T : IComparable<T>
        {
            var lastElement = array[countElements - 1];
            array[countElements - 1] = searchedElement;
            int index = 0;

            while (array[index].CompareTo(searchedElement) != 0)
            {
                index++;
            }

            array[countElements - 1] = lastElement;

            if ((index < countElements - 1) || (array[index].CompareTo(searchedElement) == 0))
                return index.ToString();
            return NOT_FOUND;
        }

        public static string RecursiveSearch<T>(T[] array, int countElements, int index, T searchedElement) where T : IComparable<T>
        {
            if (index > countElements)
            {
                return NOT_FOUND;
            }
            else if (array[index].CompareTo(searchedElement) == 0)
            {
                return index.ToString();
            }
            else
            {
                return RecursiveSearch<T>(array, countElements, index + 1, searchedElement);
            }
        }
    }
}
