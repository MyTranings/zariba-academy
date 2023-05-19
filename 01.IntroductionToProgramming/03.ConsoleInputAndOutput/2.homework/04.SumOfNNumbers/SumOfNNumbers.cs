//4. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.
using System;
class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("How many numbers will you enter: ");
        uint count = uint.Parse(Console.ReadLine());
        int sum = 0;

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter a number: ");
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Sum of the numbers is: {0}", sum);
    }
}