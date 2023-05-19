using System;
using System.Collections.Generic;

class ListTDemo
{
    static void Main()
    {
        List<int> listOfNumbers = new List<int>();
        listOfNumbers.Add(5);
        listOfNumbers.Add(10);
        listOfNumbers.Add(15);
        Console.WriteLine(string.Join(", ", listOfNumbers));
        listOfNumbers.Remove(10);
        Console.WriteLine(string.Join(", ", listOfNumbers));
        //Count -> number of non-empty elemnts
        //Capacity -> number of total elemnts in the array (capacity)
        Console.WriteLine("Count: {0} , Capacity: {1}",listOfNumbers.Count,listOfNumbers.Capacity);
        listOfNumbers.Add(5);
        listOfNumbers.Add(15);
        listOfNumbers.Add(-7);
        Console.WriteLine("Count: {0} , Capacity: {1}", listOfNumbers.Count, listOfNumbers.Capacity);
        listOfNumbers.Remove(5);
        Console.WriteLine(string.Join(", ",listOfNumbers));

    }
}

