using NUnit.Framework;
using System;

namespace TestProject
{
    [TestFixture]
    public class TestBinarySearch
    {
        private string[] stringArray;
        private int[] intArray;

        [SetUp]
        public void Setup()
        {
            int countElement = 10;

            SetupStringArray(countElement);
            SetupIntegerArray(countElement);
        }


        [TestCase(2, "2", ExpectedResult = true)]
        [TestCase(13, Algorithms.BinarySearch.NOT_FOUND,ExpectedResult = true)]
        public bool TestIntArray(int input, string result)
        {
            string stringIndex = Algorithms.BinarySearch.Search(intArray, 9, input);
            return result.CompareTo(stringIndex) == 0;
        }

        [TestCase("text9", "9", ExpectedResult = true)]
        [TestCase("text37", Algorithms.BinarySearch.NOT_FOUND, ExpectedResult = true)]
        public bool TestStringArray(string input, string result)
        {
            string stringIndex = Algorithms.BinarySearch.Search(stringArray, 9, input);
            return result.CompareTo(stringIndex) == 0;
        }

        private void SetupStringArray(int countElements)
        {
            stringArray = new string[countElements];

            for (int i = 0; i < countElements; i++)
            {
                stringArray[i] = "text" + i;
            }
        }
        private void SetupIntegerArray(int countElements)
        {
            intArray = new int[countElements];

            for (int i = 0; i < countElements; i++)
            {
                intArray[i] = i;
            }
        }
    }
}
