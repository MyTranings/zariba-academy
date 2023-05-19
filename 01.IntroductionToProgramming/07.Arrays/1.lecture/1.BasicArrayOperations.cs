using System;

class BasicArrayOperations
{
    static void Main()
    {
        //Reversing an array
        int[] arrayOfNumbers = { 1, 2, 10, 4, 5,-5 };
        int[] reversedArray = new int[arrayOfNumbers.Length];

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            reversedArray[arrayOfNumbers.Length-i-1] = arrayOfNumbers[i]; //i -> 0,1,2,3,4,5; 
                                                // index -> 5,4,3,2,1,0
        }
        Console.WriteLine();
    }
}

