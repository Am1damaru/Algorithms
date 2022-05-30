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

        public static void MergeSort<T>(T[] array, int initialIndexSubarray, int finalIndexSubarray) where T : IComparable<T>
        {
            if (initialIndexSubarray >= finalIndexSubarray)
            {
                return;
            } 
            else
            {
                int middleIndexSubarray = (finalIndexSubarray + initialIndexSubarray) / 2;
                MergeSort(array, initialIndexSubarray, middleIndexSubarray);
                MergeSort(array, middleIndexSubarray + 1, finalIndexSubarray);
                Merge(array, initialIndexSubarray, middleIndexSubarray, finalIndexSubarray);
            }
        }



        #region SupportMethods
        private static void Merge<T>(T[] array, int initialIndexSubarray, int middleIndexSubarray, int finalIndexSubarray) where T : IComparable<T>
        {
            int sizeFirstArray = middleIndexSubarray - initialIndexSubarray + 1;
            int sizeSecondArray = finalIndexSubarray - middleIndexSubarray;
            T[] firstArray = new T[sizeFirstArray];
            T[] secondArray = new T[sizeSecondArray];
            Array.Copy(array, initialIndexSubarray, firstArray, 0, sizeFirstArray);
            Array.Copy(array, middleIndexSubarray + 1, secondArray, 0, sizeSecondArray);

            int i = 0;
            int j = 0;

            for (int index = initialIndexSubarray; index <= finalIndexSubarray; index++)
            {
                if ((j >= secondArray.Length) || (i < firstArray.Length && (firstArray[i].CompareTo(secondArray[j]) <= 0)))
                {
                    array[index] = firstArray[i];
                    i++;
                }
                else
                {
                    array[index] = secondArray[j];
                    j++;
                }
            }
        }
        #endregion
    }
}
