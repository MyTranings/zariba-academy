using System;

class ArithmenticOperations
{
    static void Main(string[] args)
    {
        int firstNumber = 7;
        int secondNumber = 11;

        Console.WriteLine("\n\nNumber one is: {0}",firstNumber);
        Console.WriteLine("Number two is: {0}",secondNumber);
        Console.WriteLine("The sum is: {0}",firstNumber+secondNumber);
        Console.WriteLine("The product is: {0}",firstNumber*secondNumber);
        Console.WriteLine("Division with remainder: {0} rem {1}",secondNumber/firstNumber,secondNumber%firstNumber);

        Console.WriteLine(firstNumber+(secondNumber++));
        Console.WriteLine("\n\nNumber one is: {0}", firstNumber);
        Console.WriteLine("Number two is: {0}", secondNumber);
        Console.WriteLine(firstNumber+++secondNumber);
        Console.WriteLine("\n\nNumber one is: {0}", firstNumber);
        Console.WriteLine("Number two is: {0}", secondNumber);
        int number = 5 + 5 * 23;

        Console.WriteLine("\n\n\n\n");
        Console.WriteLine(13.0/7);
        Console.WriteLine(0/5);
        Console.WriteLine(5.0/0);
        Console.WriteLine(-5.0/0);
        Console.WriteLine(0.0/0);

        Console.WriteLine((double)firstNumber/secondNumber);
    }
}

