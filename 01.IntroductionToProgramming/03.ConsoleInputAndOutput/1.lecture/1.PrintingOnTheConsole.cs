using System;

class PrintingOnTheConsole
{
    static void Main(string[] args)
    {
        int firstNumber = 158;//1x10^1 + 2x10^0 = 10 + 2
        int secondNumber = 123451;
        Console.WriteLine("The first number is: " + firstNumber + " the second number is: "
            + secondNumber + " and their sum is: " + (firstNumber + secondNumber));
        //Quicker and easier
        Console.Write("The first number is: {0} the second number is: {1} and their sum is {2}", firstNumber, secondNumber, firstNumber + secondNumber);
        Console.WriteLine("\n\n\n");

        Console.WriteLine("{0,4:X}", firstNumber);
        Console.WriteLine("{0,4:E2}", secondNumber);

        string someRandomText = @"""Why are you smiling?"", he said";

        Console.WriteLine(someRandomText);
        

    }
}

