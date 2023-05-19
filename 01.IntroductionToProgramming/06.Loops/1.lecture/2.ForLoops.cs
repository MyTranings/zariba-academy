using System;

class ForLoops
{
    static void Main()
    {
        //for(intialization;conditions;update)
        //{
        //     statements
        //}

        //Print numbers from 1 to 10
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n" + new string('-', 50));

        int sum = 0;
        for (int i = 1; i <= 11; i++)
        {
            sum = sum + i;
        }
        Console.WriteLine("The sum from 1 to 11 is {0} ", sum);

        //Also the product from 1 to 6;
        Console.WriteLine("\n" + new string('-', 50));
        int factorial = 1;
        for (int i = 1; i <= 6; i++)
        {
            factorial = factorial * i;
        }
        Console.WriteLine("The product is {0}", factorial);

        //Prime numbers.
        Console.WriteLine("\n" + new string('-', 50));
        int primeNumber = int.Parse(Console.ReadLine());
        int maxDivisor = (int)Math.Sqrt(primeNumber);
        bool isPrime = true;

        for (int i = 2; i <= maxDivisor; i++)
        {
            if (primeNumber % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        Console.WriteLine("Is the number {0} prime? {1}", primeNumber, isPrime);

        //Calculate product between n and m
        Console.WriteLine("\n" + new string('-', 50));
        int n = 5;
        int m = 11;
        int product = 1;

        for (int i = n; i <= m; i++)
        {
            product = product * i;
        }
        Console.WriteLine("The product between {0} and {1} is {2}", n, m, product);

        //Sum of all powers of 2;
        Console.WriteLine("\n" + new string('-', 50));
        for (int i = 1,sumPowersOf2=1; i<=1025; i*=2,sumPowersOf2=sumPowersOf2+i)
        {
            Console.WriteLine("i={0}    sum={1}",i,sumPowersOf2);
        }

        //Sum all odd numbers which are not divisible by 7.
        // Example for the "continue" operator
        Console.WriteLine("\n" + new string('-', 50));
        int sumOddNumbers = 0;
        for (int i = 1; i <= 9; i+=2)
        {
            if (i % 7 == 0)
            {
                continue;
            }
            sumOddNumbers = sumOddNumbers + i;
        }
        Console.WriteLine("The sum of all odd numbers between 1 and 9, not divisible by 7 is {0}",
            sumOddNumbers);
    }
}