// 2. Write a boolean expression that checks if an integer can be divided by 2, 3 and 5 without remainder(use logical operators).
using System;

class DividedBy235
{
    static void Main()
    {
        Console.Write("Enter a number to check if it's divided by 2, 3 and 5 withoud remainder: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Is the number divided withoud remainder by 2, 3 and 5: {0}", n % 2 == 0 && n % 3 == 0 && n % 5 == 0);
    }
}
