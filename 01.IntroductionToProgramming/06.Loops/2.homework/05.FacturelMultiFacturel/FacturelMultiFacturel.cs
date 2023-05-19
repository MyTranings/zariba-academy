// 5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
using System;

class FacturelMultiFacturel
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int nFac = 1;

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        int kFac = 1;
        int subFac = 1;

        for (int i = 1; i <= n; i++)
        {
            nFac *= i;
        }

        for (int j = 1; j <= k; j++)
        {
            kFac *= j;
        }

        for (int m = 1; m <= k - n; m++)
        {
            subFac *= m;
        }

        Console.WriteLine("{0} * {1} / {2} = {3}", n, k, subFac, (nFac * kFac) / subFac);
    }
}