// 4. Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

class FacturelDevideFacturel
{
    static void Main()
    {
        Console.Write("Enter n: ");
        uint n = uint.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        uint k = uint.Parse(Console.ReadLine());

        uint nFacturel = 1;
        uint kFacturel = 1;

        for (uint i = 1; i <= n; i++)
        {
            nFacturel *= i;
        }

        for (uint j = k; j >= 1; j--)
        {
            kFacturel *= j;
        }
        Console.WriteLine("N!/K! = {0}", nFacturel/kFacturel);
    }
}