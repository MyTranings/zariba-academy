// 3. Write a program that evaluates the area of a trapezium, given its sides and height.

using System;
using System.Globalization;
using System.Threading;

class AreaOfTrapezium
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter side b1: ");
        float b1 = float.Parse(Console.ReadLine());

        Console.Write("Enter side b2: ");
        float b2 = float.Parse(Console.ReadLine());

        Console.Write("Enter height: ");
        float h = float.Parse(Console.ReadLine());

        Console.WriteLine("Area of trapezium is : {0}", ((b1 + b2) * h) / 2);
    }
}
