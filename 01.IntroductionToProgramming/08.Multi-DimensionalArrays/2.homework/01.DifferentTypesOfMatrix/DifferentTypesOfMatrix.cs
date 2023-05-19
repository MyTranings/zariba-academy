//1. Write a program that prints the following matrices with n rows and n columns for a given number n: 
//	All examples are for n=4.

//   1  5  9  13      1  8  9  16      7  11 14 16
//   2  6  10 14      2  7  10 15      4  8  12 15
//   3  7  11 15      3  6  11 14      2  5  9  13
//   4  8  12 16      4  5  12 13      1  3  6  10

using System;

class DifferentTypesOfMatrix
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int cursorPosition = 0;
        int maxItereations = 0;

        Console.Clear();

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                maxItereations++;
                Console.SetCursorPosition(cursorPosition, row);
                Console.Write("{0}", maxItereations);
            }
            cursorPosition += col + 2;
        }

        cursorPosition = 0;
        maxItereations = 0;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = n + 1; row <= n * 2; row++)
                {
                    maxItereations++;
                    Console.SetCursorPosition(cursorPosition, row);
                    Console.Write("{0}", maxItereations);
                }
            }
            else
            {
                for (int row = n * 2; row >= n +1; row--)
                {
                    maxItereations++;
                    Console.SetCursorPosition(cursorPosition, row);
                    Console.Write("{0}", maxItereations);
                }
            }
            cursorPosition += col + 2;
        }

        cursorPosition = 0;
        maxItereations = 0;


        for (int row = n * 3; row >= n * 4; row++)
        {
            for (int col = 0; col < n; col++)
            {
                maxItereations++;
                Console.SetCursorPosition(cursorPosition, row);
                Console.Write("{0}", maxItereations);
            }
            cursorPosition += 0;
        }
    }
}