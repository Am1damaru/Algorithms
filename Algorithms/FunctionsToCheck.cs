namespace Algorithms
{
    public static class FunctionsToCheck
    {
        public static void CheckLinearSearchWithSentinel()
        {
            int countElement = 10;
            string[] array = new string[countElement];

            for (int i = 0; i < countElement; i++)
            {
                array[i] = "text" + i;
            }
            Console.WriteLine("Array: ");
            foreach (var s in array)
                Console.Write(s + "   ");
            Console.WriteLine();

            int index;
            string stringIndex = Algorithms.LinearSearch.SearchWithSentinel(array, 9, "text" + 9);

            if (stringIndex != Algorithms.LinearSearch.NOT_FOUND)
            {
                index = int.Parse(stringIndex);
                Console.WriteLine("Found element = " + array[index]);
                Console.WriteLine("Index = " + index);
            }
            else
            {
                Console.WriteLine("Element not found");
            }
            Console.ReadLine();
        }
    }
}
