// 2. Write a program that finds the largest of 3 integers, using if statements.

using System;

class LargestOf3Digit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n3 = int.Parse(Console.ReadLine());

        if (n2 >= n1 && n2 >= n3)
        {
            Console.WriteLine("{0} is the largest number", n2);
        }
        else if (n3 >= n1 && n3 >= n2)
        {
            Console.WriteLine("{0} is the larget number", n3);
        }
        else
        {
            Console.WriteLine("{0} is the larget number", n1);
        }
    }
}
