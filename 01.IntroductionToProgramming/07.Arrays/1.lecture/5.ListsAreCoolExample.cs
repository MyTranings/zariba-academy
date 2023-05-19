using System;
using System.Collections.Generic;
using System.Linq;
class ListsAreCool
{
    static void Main()
    {
        //Get an array and add one element at the end.
        int[] array = { 1, 2, 3, 4, 5 };
        int[] extendedArray = new int[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            extendedArray[i] = array[i];
        }
        extendedArray[array.Length] = 6;
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine(string.Join(", ", extendedArray));

        //With Lists this is simply: 
        List<int> coolList = new List<int> { 1, 2, 3, 4, 5 };
        coolList.Add(6);
        Console.WriteLine(string.Join(", ", coolList));
        Console.WriteLine(coolList[5]);
    }
}

