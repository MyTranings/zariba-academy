// 6. Write a program to read your first and last names and print them on the console, separated by space.

using System;

class InputOutput
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        Console.WriteLine(firstName + " " + lastName);
    }
}