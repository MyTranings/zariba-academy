using System;

class WhileDoWhile
{
    static void Main()
    {
        //WHILE LOOP
        //...
        //while(condition)
        //{
        //      Statements;
        //}
        //... other statements

        //DO WHILE LOOP
        //do
        //{
        //      Statements;
        //}
        //while (condition);
        //... other statements


        //Print the numbers from 1 to 10.
        int counter = 0;
        while (counter<=10)
        {
            Console.Write("{0} ",counter);
            counter++;
        }
        Console.WriteLine("\n"+new string('-', 50));
        //Print the sum of the first 7 numbers.
        int sum = 0;
        int singleSumValue = 1;
        Console.Write("The sum of the numbers from 1 to 7 is:");
        while (singleSumValue<=7)
        {
            sum = sum + singleSumValue;
            singleSumValue++; 
        }
        Console.WriteLine(sum);

        Console.WriteLine("\n" + new string('-', 50));
        //Check if a number is Prime.
        //We need to check if all values between 2 and sqrt(primeNumber) 
        //divide primeNumber. If one does-> not prime. If all don't ->prime
        int primeNumber = int.Parse(Console.ReadLine());
        int divisor = 2;
        //Or you can use Math.Round(Math.Sqrt(primeNumber)) Convert.ToInt32 (math.sqrt...)
        int maxDivisor = (int)Math.Sqrt(primeNumber);
        bool isPrime = true;
        bool isValidPrime = true;

        if (primeNumber<=1)
        {
            Console.WriteLine("Error! You suck!");
            isValidPrime = false;
            isPrime = false;
        }

        while (divisor<=maxDivisor && isValidPrime)
        {
            //Check if a divisor divides primeNumber
            if (primeNumber%divisor == 0)
            {
                isPrime = false;
                //breaks the first outer loop.
                break;
            }
            divisor++;
        }
        Console.WriteLine("Is {0} prime? {1}",primeNumber,isPrime);
        Console.WriteLine("\n" + new string('-', 50));
        //Calculate N! = 1x2x3...xN
        int factorialNumber = primeNumber;
        int product = 1;
        int index = 1;

        while (index<=factorialNumber)
        {
            product = product * index;
            index++;
        }
        Console.WriteLine("{0}!={1}",factorialNumber,product);

        //infinite loops
        // while (true)
        // {
        //     //To stop it we can have:
        //     //Game over conditions
        //     //Health<0
        //     //...
        //     //done with break
        // }

        while (false)
        {
            Console.WriteLine("This is never executed in the while Loop.");
        }

        do
        {
            Console.WriteLine("This is now executed in the do while loop.");
        }
        while (false);
    }
}


