// 1. Write an if statement that exchanges the values of 2 numbers if the first is bigger than the second

using System;

class ExchangeIfBigger
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int n2 = int.Parse(Console.ReadLine());
        int buff = 0;

        if (n1 > n2)
        {
            buff = n1;
            n1 = n2;
            n2 = buff;
            Console.WriteLine("The values of number is exchanged!");
        }
        else
        {
            Console.WriteLine("The values of numbers wasn't exchanged!");
        }
        
    }
}