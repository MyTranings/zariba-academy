//02. Read two floating point numbers from the console.Write a program to successfully compare these floating point number with precision of 0.0 00 01. e.g. 3. 00 06 and 3.1 false,  3. 00 00 07 and  3.00 00 08 true
using System;
using System.Globalization;
using System.Threading;

class FloatingPoint
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        float num1 = float.Parse(Console.ReadLine());
        float num2 = float.Parse(Console.ReadLine());

        Console.WriteLine(Math.Round(num1, 5) == Math.Round(num2, 5));
    }
}