// 5. Write a program that reads an integer number n from the console and prints all the numbers in the interval[1..n], each on a single line.

using System;

class NumbersInInterval
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("The numbers between 1 and {0} are: ", number);
        for (int i = 2; i < number; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}