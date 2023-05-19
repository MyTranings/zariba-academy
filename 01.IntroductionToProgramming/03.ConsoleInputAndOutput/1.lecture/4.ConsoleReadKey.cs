using System;

class ConsoleReadKey
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo someKey = Console.ReadKey();
        Console.WriteLine("You have pressed: {0}",someKey.KeyChar);
        Console.WriteLine("Modifiers: {0}",someKey.Modifiers);

        Console.WriteLine(Console.WindowHeight);
    }
}

