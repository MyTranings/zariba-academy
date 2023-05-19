//1. Write an expression that checks if given integer is odd or even.

using System;

class EvenOdd
{
    static void Main()
    {
        Console.Write("Enter a number to check if is even or odd: ");
        int num = int.Parse(Console.ReadLine());

        if (num % 2 == 0)
        {
            Console.WriteLine("The number is even!");
        }
        else
        {
            Console.WriteLine("The number is odd");
        }
    }
}