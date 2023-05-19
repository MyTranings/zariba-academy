//2. Write a program that gets two numbers from the console and prints the greater of them. Dont use if statements.
using System;

class GreaterNumber
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.WriteLine("The greater number is {0}", n1 > n2 ? n1 : n2);
    }
}