// 6. Write an expression that checks if a given point(x, y) is within a circle with radius 4 and centre at(0,0)

using System;
using System.Globalization;
using System.Threading;

class PointInCircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter point X: ");
        float pointX = float.Parse(Console.ReadLine());

        Console.Write("Enter point Y: ");
        float pointY = float.Parse(Console.ReadLine());

        float r = 4f;
        float circleX = 0f;
        float circleY = 0f;

        float calcX = (pointX - circleX) * (pointX - circleX);
        float calcY = (pointY - circleY) * (pointY - circleY);

        if ((calcX + calcY) < r * r)
        {
            Console.WriteLine("Point is in the circle.");
        }
        else if((calcX + calcY) == r * r) 
        {
            Console.WriteLine("Point is on the circle.");
        }
        else
        {
            Console.WriteLine("Point is outside of the circle.");
        }
    }
}