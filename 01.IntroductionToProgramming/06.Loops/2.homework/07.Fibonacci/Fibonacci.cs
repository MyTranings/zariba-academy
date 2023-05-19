// 7. Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci:	 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 

using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int fib = 1;
        int prevNum = 0;
        int buff = 0;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(fib);
            sum += fib;
            buff = fib;
            fib += prevNum;
            prevNum = buff;
        }

        Console.WriteLine(sum);
    }
}