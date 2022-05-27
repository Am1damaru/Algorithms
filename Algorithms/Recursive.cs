namespace Algorithms
{
    public static class Recursive
    {
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new Exception("Number is not valid");
            }

            if (number == 0)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        /// <summary>
        /// Don't use this
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int BadFactorial(int number)
        {
            if (number < 0)
            {
                throw new Exception("Number is not valid");
            }

            if (number == 0)
            {
                return 1;
            }
            else
            {
                return Factorial(number + 1) / (number + 1);
            }
        }

        public static string RecursiveLinearSearch<T>(T[] array, int countElements, int index, T searchedElement) where T : IComparable<T>
        {
            return LinearSearch.RecursiveSearch<T>(array, countElements, index, searchedElement);
        }

        public static string RecursiveBinarySearch<T>(T[] array, int leftLimit, int rightLimit, T searchedElement) where T : IComparable<T>
        {
            return BinarySearch.RecursiveSearch<T>(array, leftLimit, rightLimit, searchedElement);
        }
    }
}
