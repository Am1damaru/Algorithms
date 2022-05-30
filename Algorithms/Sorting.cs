using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Sorting
    {
        private static Random _random = new Random();
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
                Swap(array, smallest, i);
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

        public static void QuickSort<T>(T[] array, int initialIndexSubarray, int finalIndexSubarray) where T : IComparable<T>
        {
            if (initialIndexSubarray >= finalIndexSubarray)
            {
                return;
            }
            else
            {
                int middleIndex = Partition(array, initialIndexSubarray, finalIndexSubarray);
                QuickSort(array, initialIndexSubarray, middleIndex - 1);
                QuickSort(array, middleIndex + 1, finalIndexSubarray);
            }
        }

        public static int[] CountingSort(int[] array, int countElementsArray, int rangeValuesArray)
        {
            int[] intermediateArray = new int[rangeValuesArray];
            Array.Fill(intermediateArray, 0);
            CountKeysEqual(array, intermediateArray, countElementsArray);
            CountKeysLess(intermediateArray);
            return Rearrange(array, intermediateArray, countElementsArray);
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

        private static int Partition<T>(T[] array, int initialIndexSubarray, int finalIndexSubarray) where T : IComparable<T>
        {
            int randomIndex = _random.Next(initialIndexSubarray, finalIndexSubarray + 1);
            Swap(array, randomIndex, finalIndexSubarray);
            int border = initialIndexSubarray;
            for (int index = initialIndexSubarray; index < finalIndexSubarray; index++)
            {
                if (array[index].CompareTo(array[finalIndexSubarray]) <= 0)
                {
                    Swap(array, index, border);
                    border++;
                }
            }
            Swap(array, border, finalIndexSubarray);
            return border;
        }

        private static void CountKeysEqual(int[] array, int[] intermediateArray, int countElementsArray)
        {
            for (int index = 0; index < countElementsArray; index++)
            {
                int key = array[index];
                intermediateArray[key] += 1;
            }
        }

        private static void CountKeysLess(int[] intermediateArray)
        {
            int previousFirstValue = intermediateArray[0];
            int previousSecondValue;
            intermediateArray[0] = 0;

            for (int index = 1; index < intermediateArray.Length; index++)
            {
                previousSecondValue = intermediateArray[index];
                intermediateArray[index] = previousFirstValue + intermediateArray[index - 1];
                previousFirstValue = previousSecondValue;
            }
        }

        private static int[] Rearrange(int[] array, int[] intermediateArray, int countElementsArray)
        {
            int[] finalArray = new int[countElementsArray];

            for (int counter = 0; counter < countElementsArray; counter++)
            {
                int key = array[counter];
                int index = intermediateArray[key];
                finalArray[index] = array[counter];
                intermediateArray[key] += 1;
            }

            return finalArray;
        }

        private static void Swap<T>(T[] array, int firstIndex, int SecondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[SecondIndex];
            array[SecondIndex] = temp;
        }
        #endregion
    }
}
