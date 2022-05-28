using NUnit.Framework;
using System;

namespace TestProject
{
    [TestFixture]
    public class TestLinearSearch
    {
        private string[] stringArray;
        private int[] intArray;

        private Func<int[], int, int, string>[] intFunctions = { 
            Algorithms.LinearSearch.BasicSearch, 
            Algorithms.LinearSearch.BetterSearch,
            Algorithms.LinearSearch.SearchWithSentinel
        };

        private Func<string[], int, string, string>[] stringFunctions = {
            Algorithms.LinearSearch.BasicSearch,
            Algorithms.LinearSearch.BetterSearch,
            Algorithms.LinearSearch.SearchWithSentinel
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
        [TestCase(2)]
        public void PositiveTestIntArray(int functionNumber)
        {
            string stringIndex = intFunctions[functionNumber](intArray, intArray.Length, 9);
            int index = int.Parse(stringIndex);
            Assert.AreEqual(index, 9);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void PositiveTestStringArray(int functionNumber)
        {
            string stringIndex = stringFunctions[functionNumber](stringArray, stringArray.Length, "text" + 9);
            int index = int.Parse(stringIndex);
            Assert.AreEqual(index, 9);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void NegativeTestIntArray(int functionNumber)
        {
            string stringIndex = intFunctions[functionNumber](intArray, intArray.Length, 13);
            Assert.AreEqual(stringIndex, Algorithms.LinearSearch.NOT_FOUND);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void NegativeTestStringArray(int functionNumber)
        {
            string stringIndex = stringFunctions[functionNumber](stringArray, stringArray.Length, "text" + 37);
            Assert.AreEqual(stringIndex, Algorithms.LinearSearch.NOT_FOUND);
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
