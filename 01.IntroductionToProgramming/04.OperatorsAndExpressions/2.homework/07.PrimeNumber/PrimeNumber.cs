// 7. Write an expression that checks if a given positive integer n<=100 is prime.

using System;

class PrimeNumber
{
    static void Main()
    {
        Console.Write("Enter a positive number: ");
        uint n = uint.Parse(Console.ReadLine());
        if (n <= 100)
        {
            Console.WriteLine();
            //Variant 1
            Console.WriteLine("Variant 1:");
            if (n % 2 != 0 && n % 3 != 0 && n % 5 != 0 && n % 7 != 0)
            {
                Console.WriteLine("Number is prime!\n");
            }
            else
            {
                Console.WriteLine("Number is not prime!\n");
            }
            //Variant 2
            Console.WriteLine("Variant 2: ");
            bool isPrime = true;

            for (uint i = 2; i < n; i++)
            {
                if (n % i == 0 && i != n)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("Number is prime!");
            }
            else
            {
                Console.WriteLine("Number is not prime!");
            }
        }
    }
}