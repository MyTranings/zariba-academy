namespace ExtensionMethods
{
    using System;
    using ExtensionMethods.Extensions;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main()
        {
            string text = "Hello, my name is Martin Antonov.";
            int result = text.CountWords();
            Console.WriteLine(result);

            List<int> testList = new List<int>() { 4, 5, 1, 0, 3 };
            testList.IncreaseWithNumber(3);
            foreach (var number in testList)
            {
                Console.WriteLine(number);
            }
        }
    }
}
