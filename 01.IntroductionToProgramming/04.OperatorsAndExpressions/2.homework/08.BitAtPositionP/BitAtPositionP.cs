// 8. Write a Boolean expression that returns if the bit at position p (counting from 0 ) in a given integer v has value of 1.


using System;

class BitAtPositionP
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int v = int.Parse(Console.ReadLine());

        Console.Write("Enter a position: ");
        int p = int.Parse(Console.ReadLine());

        int mask = 1 << p;
        mask = mask & v;
        mask = mask >> p;

        Console.WriteLine("Bit at poision {0} is: {1}", v, Convert.ToString(mask, 2));
    }
}
