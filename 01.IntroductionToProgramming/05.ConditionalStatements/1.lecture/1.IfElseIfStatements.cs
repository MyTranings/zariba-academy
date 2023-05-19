using System;

class IfElseIfStatements
{
    static void Main()
    {
        //if(condition)
        //{
        //      statements
        //}

        //Checking if one number is higher than another one
        int firstNumber = 51;
        int secondNumber = 50;

        if (firstNumber < secondNumber)
        {
            Console.WriteLine("Second number is bigger.");
        }
        else
        {
            Console.WriteLine("First number is bigger.");
        }

        Console.WriteLine("\n\n");
        //check if a number is divisible by 6 (using and operator)
        //Ways to fix long boolean expressions:
        //bool isDivisibleBy6 = firstNumber % 3 == 0 && firstNumber % 2 == 0;
        if ((firstNumber % 3 == 0 && firstNumber % 2 == 0) || firstNumber % 5 == 0)
        {
            Console.WriteLine("The number {0} is divisible by 6 or by 5", firstNumber);
        }

        Console.WriteLine("\n\n");

        //Given a digit from 0 to 9, print the name
        int digit = int.Parse(Console.ReadLine());

        if (digit == 0)
        {
            Console.WriteLine("Zero");
        }
        else if (digit == 1)
        {
            Console.WriteLine("One");
        }
        else if (digit == 2)
        {
            Console.WriteLine("Two");
        }
        else if (digit == 3)
        {
            Console.WriteLine("Three");
        }
        else if (digit == 4)
        {
            Console.WriteLine("Four");
        }
        else if (digit == 5)
        {
            Console.WriteLine("Five");
        }
        else if (digit == 6)
        {
            Console.WriteLine("Six");
        }
        else if (digit == 7)
        {
            Console.WriteLine("Seven");
        }
        else if (digit == 8)
        {
            Console.WriteLine("Eight");
        }
        else if (digit == 9)
        {
            Console.WriteLine("Nine");
        }
        else
        {
            Console.WriteLine("You didn't input a digit. You suck!");
        }
    }
}

