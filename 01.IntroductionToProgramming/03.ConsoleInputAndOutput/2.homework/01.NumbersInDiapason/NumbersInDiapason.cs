// 1. Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division with p by 5 is 0 (inclusive). Example: p(17,25) = 2
using System;

class NumbersInDiapason
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        uint n1 = uint.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        uint n2 = uint.Parse(Console.ReadLine());
        uint counter = 0;

        for (uint i = n1; i <= n2; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine("Numbers that the reminder of the division with 5 is 0 are: {0}", counter);
    }
}