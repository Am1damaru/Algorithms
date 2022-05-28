using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Sorting
    {
        public static void SelectionSort<T>(T[] array, int amountSortedItems) where T : IComparable<T>
        {
            for (int i = 0; i < amountSortedItems - 1; i++)
            {
                int smallest = i;

                for (int j = i + 1; j < amountSortedItems; j++)
                {
                    if (array[j].CompareTo(array[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }

                var temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }
        }

        public static void InsertionSort<T>(T[] array, int amountSortedItems) where T : IComparable<T>
        {
            for (int i = 1; i < amountSortedItems; i++)
            {
                var key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
