// 5. Write a boolean expression for finding if the bit 2 (counting from 0) of a given integer is 1 or 0.

using System;

class BitAt2ndPosition
{
    static void Main()
    {
        Console.Write("Enter a number to check the second big: ");
        int n = int.Parse(Console.ReadLine());
       
        int mask = 1 << 1;
        mask = mask & n;
        mask = mask >> 1;

        Console.WriteLine("The bit at if the 2nd position is the one with index of 1: {0}", mask);

        mask = 1 << 2;
        mask = mask & n;
        mask = mask >> 2;

        Console.WriteLine("The bit at if the 2nd position is the one with index of 2: {0}", mask);
    }
}