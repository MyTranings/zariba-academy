using System;
using System.Linq;

class InputOutput
{
    static void Main()
    {
        //Reading arrays #1
        int numberOfElements = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            arrayOfNumbers[i] = int.Parse(Console.ReadLine());
        }
        // Reading arrays #2
        string text = Console.ReadLine();
        int[] arrayFromString = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(element => int.Parse(element))
                                    .ToArray();

        //Printing arrays #1
        for (int i = 0; i < numberOfElements; i++)
        {
            Console.WriteLine("arr[{0}]={1}", i, arrayOfNumbers[i]);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        //PrintingArray  #2
        foreach (var number in arrayOfNumbers)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        //PrintingArray #3

        Console.WriteLine(string.Join(", ", arrayOfNumbers));
        Console.WriteLine(string.Join("__", arrayFromString));

        //PrintingArray #4
        arrayOfNumbers.ToList().ForEach(x => Console.WriteLine(x));

    }
}

