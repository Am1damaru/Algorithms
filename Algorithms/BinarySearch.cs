using System;

namespace Algorithms
{
    public static class BinarySearch
    {
        public const string NOT_FOUND = "NOT-FOUND";

        public static string Search<T>(T[] sortedArray, int inputRightLimit, T searchedElement) where T : IComparable<T>
        {
            int leftLimit = 0;
            int rightLimit = inputRightLimit;
            int middleIndex;

            while(leftLimit <= rightLimit)
            {
                middleIndex = (leftLimit + rightLimit) / 2;

                if (sortedArray[middleIndex].CompareTo(searchedElement) == 0)
                {
                    return middleIndex.ToString();
                }
                else if (sortedArray[middleIndex].CompareTo(searchedElement) < 0)
                {
                    leftLimit = middleIndex + 1;
                }
                else
                {
                    rightLimit = middleIndex - 1;
                }
            }

            return NOT_FOUND;
        }

        public static string RecursiveSearch<T>(T[] sortedArray, int leftLimit, int rightLimit, T searchedElement) where T : IComparable<T>
        {
            if (leftLimit > rightLimit)
            {
                return NOT_FOUND;
            }

            int middleIndex = (leftLimit + rightLimit) / 2;

            if (sortedArray[middleIndex].CompareTo(searchedElement) == 0)
            {
                return middleIndex.ToString();
            }
            else if (sortedArray[middleIndex].CompareTo(searchedElement) < 0)
            {
                return RecursiveSearch(sortedArray, middleIndex + 1, rightLimit, searchedElement);
            }
            else
            {
                return RecursiveSearch(sortedArray, leftLimit, middleIndex - 1, searchedElement);
            }
        }
    }
}
