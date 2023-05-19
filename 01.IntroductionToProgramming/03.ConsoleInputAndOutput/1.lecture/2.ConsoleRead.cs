using System;

class ConsoleRead
{
    static void Main(string[] args)
    {
        int characterNumber = Console.Read();
        char character = (char)characterNumber;
        Console.WriteLine("The symbol {0} has number {1}",character, characterNumber);
    }
}

