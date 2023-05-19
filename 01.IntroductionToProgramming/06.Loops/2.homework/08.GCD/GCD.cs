// 8. Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm(find it in Internet).

using System;

class GCD
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int m = int.Parse(Console.ReadLine());

        int max = n;
        int min = m;

        int buff = 0;

        if (m > n)
        {
            max = m;
            min = n;
        }

        while (max - min != 0)
        {
            max = max - min;
            if (max < min)
            {
                buff = max;
                max = min;
                min = buff;
            }
        }

        Console.WriteLine("Greatest Common Divisor: {0}", max);
    }
}