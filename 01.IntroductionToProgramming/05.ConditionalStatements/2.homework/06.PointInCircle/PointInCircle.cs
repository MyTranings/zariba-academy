//6. Write an expression that checks if a given point (x,y) is within a circle with radius 4 and centre at (0,0)
using System;
using System.Globalization;
using System.Threading;

class PointInCircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a point x: ");
        float pointX = float.Parse(Console.ReadLine());

        Console.Write("Enter a point y: ");
        float pointY = float.Parse(Console.ReadLine());

        float circleX = 0f;
        float circleY = 0f;
        double r = 4f;

        double calcX = (pointX - circleX) * (pointX - circleX);
        double calcY = (pointY - circleY) * (pointY - circleY);

        if ((calcX + calcY) < r * r)
        {
            Console.WriteLine("The point ({0},{1}) is in the circle!", pointX, pointY);
        }
        else if ((calcX + calcY) == r * r)
        {
            Console.WriteLine("The point ({0},{1}) is on the circle!", pointX, pointY);
        }
        else
        {
            Console.WriteLine("The point ({0},{1}) is outside the circle!", pointX, pointY);
        }
    }
}