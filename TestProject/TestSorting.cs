using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TestProject
{
    [TestFixture]
    public class TestSorting
    {
        private string[] stringArray;
        private int[] intArray;

        private Action<int[], int>[] intFunctions = {
            Algorithms.Sorting.SelectionSort,
            Algorithms.Sorting.InsertionSort
        };

        private Action<string[], int>[] stringFunctions = {
            Algorithms.Sorting.SelectionSort,
            Algorithms.Sorting.InsertionSort
        };

        [SetUp]
        public void Setup()
        {
            int countElement = 10;

            SetupStringArray(countElement);
            SetupIntegerArray(countElement);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void TestStringSort(int functionNumber)
        {
            List<string> sortedList = new List<string>(stringArray);
            sortedList.Sort();
            stringFunctions[functionNumber](stringArray, stringArray.Length);
            List<string> list = new List<string>(stringArray);
            Assert.AreEqual(list, sortedList);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void TestIntSort(int functionNumber)
        {
            List<int> sortedList = new List<int>(intArray);
            sortedList.Sort();
            intFunctions[functionNumber](intArray, intArray.Length);
            List<int> list = new List<int>(intArray);
            Assert.AreEqual(list, sortedList);
        }

        [Test]
        public void TestStringMergeSort()
        {
            List<string> sortedList = new List<string>(stringArray);
            sortedList.Sort();
            Algorithms.Sorting.MergeSort(stringArray, 0, stringArray.Length - 1);
            List<string> list = new List<string>(stringArray);
            Assert.AreEqual(list, sortedList);
        }

        [Test]
        public void TestIntMergeSort()
        {
            List<int> sortedList = new List<int>(intArray);
            sortedList.Sort();
            Algorithms.Sorting.MergeSort(intArray, 0, intArray.Length - 1);
            List<int> list = new List<int>(intArray);
            Assert.AreEqual(list, sortedList);
        }

        private void SetupStringArray(int countElements)
        {
            Random random = new Random();
            stringArray = new string[countElements];

            for (int i = 0; i < countElements; i++)
            {
                stringArray[i] = random.Next(1, 100).ToString();
            }
        }
        private void SetupIntegerArray(int countElements)
        {
            Random random = new Random();
            intArray = new int[countElements];

            for (int i = 0; i < countElements; i++)
            {
                intArray[i] = random.Next(1, 100);
            }
        }
    }
}
