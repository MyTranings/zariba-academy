// 5. Write a boolean expression for finding if the bit at position 2 (counting from 0) of a given integer is 1 or 0. e.g.If 1-> true

using System;

class CheckBitAt2Position
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int mask = 1 << 1;
        mask = n & mask;
        mask = mask >> 1;
        Console.WriteLine("Bit at position 2 is: {0}", Convert.ToBoolean(mask));
        
    }
}