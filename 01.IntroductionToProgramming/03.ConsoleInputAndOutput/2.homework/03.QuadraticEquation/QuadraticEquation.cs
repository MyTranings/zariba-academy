//3. Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it(prints its real roots).
using System;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter coefficient a: ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("Enter coefficient b: ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("Enter coefficient c: ");
        float c = float.Parse(Console.ReadLine());

        float x1 = ((-b - (float)(Math.Sqrt(b * b - 4 * a * c))) / (2 * a));
        float x2 = ((-b + (float)(Math.Sqrt(b * b - 4 * a * c))) / (2 * a));
        
        if (x1 != x1 && x2 != x2)
        {
            Console.WriteLine("No real roots!");
        }
        else if ((x1 == x1 && x2 != x2) || x1 == x2)
        {
            Console.WriteLine("Root of the equation is: {0}", x1);
        }
        else if (x1 != x1 && x2 == x2)
        {
            Console.WriteLine("Root of the equation is: {0}", x2);
        }
        else
        {
            Console.WriteLine("Roots of the equation are: {0}, {1}", x1, x2);
        }
    }
}