using System;
using System.Linq;

class SymmetryCheck
{
    static void Main()
    {
        //Check if an array is symmetric. e.g 1,2,3,3,2,1 ->sym
        //e.g. 1,2,2,3 -> Not , 1,2,3,2,1
        string text = Console.ReadLine();
        int[] arrayOfNumbers = text.Split(' ')
                                   .Select(number => int.Parse(number))
                                   .ToArray();
        bool isSymmetric = true;
        for (int i = 0; i < arrayOfNumbers.Length/2; i++)
        {
            if (arrayOfNumbers[i]!=arrayOfNumbers[arrayOfNumbers.Length-1-i])
            {
                isSymmetric = false;
                break;
            }
        }
        Console.WriteLine("Is array symmetric? {0}",isSymmetric);
        Console.WriteLine(new string(' ',50));
        //Initialize array with squared numbers.
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = arrayOfNumbers[i] * arrayOfNumbers[i];
        }
        Console.WriteLine(new string('-', 50));
        Console.WriteLine(string.Join(", ",arrayOfNumbers));

        //Initialize with the indexes
        Console.WriteLine(new string('-', 50));
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = i+1;
        }
        Console.WriteLine(string.Join(", ",arrayOfNumbers));
    }
   
}

