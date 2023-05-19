using System;

class ConsoleReadLine
{
    static void Main(string[] args)
    {
        string str1 = Console.ReadLine();
        int firstNumber = int.Parse(str1);
        str1 = Console.ReadLine();
        int secondNumber = int.Parse(str1);

       
        uint thirdNumber = uint.Parse(Console.ReadLine());

        Console.WriteLine("First Number + Second is: {0}",firstNumber+secondNumber);
    }
}

