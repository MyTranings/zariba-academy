//14. Write a program that finds all prime numbers in the range[1...10 000 000]. 
	//Use the sieve of Eratosthenes algorithm(find it in Wikipedia).

using System;
using System.Collections.Generic;

class ЕratosthenesАlgorithm
{
    static void Main()
    {
        bool[] allNumbers = new bool[10000];

        for (int i = 0; i < allNumbers.Length; i++)
        {
            allNumbers[i] = true;
        }

        for (int i = 2; i < Math.Sqrt(allNumbers.Length); i++)
        {
            if (allNumbers[i])
            {
                for (int j = i * i; j < allNumbers.Length; j = j + i)
                {
                    allNumbers[j] = false;
                }
            }
        }

        for (int i = 0; i < allNumbers.Length; i++)
        {
            if (allNumbers[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}