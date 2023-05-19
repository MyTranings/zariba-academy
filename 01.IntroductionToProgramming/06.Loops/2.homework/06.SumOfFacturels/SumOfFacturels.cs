//6. Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 +  + N!/XN

using System;

class SumOfFacturels
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());
        
        double s = 1;
        int fac;
        for (int i = 1; i <= n; i++)
        {
            fac = 1;
            for (int j = 1; j <= i; j++)
            {
                fac *= j;
            }
            s += fac / Math.Pow(x, i);
        }
        Console.WriteLine(s);
    }
}