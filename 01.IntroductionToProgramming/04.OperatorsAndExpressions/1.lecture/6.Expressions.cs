using System;

class Expressions
{
    static void Main()
    {
        //Find the area of a triangle by given 3 sides
        //Heron's Formula 

        int sideA = int.Parse(Console.ReadLine());
        int sideB = int.Parse(Console.ReadLine());
        int sideC = int.Parse(Console.ReadLine());
        double halfPerimeter = (sideA + sideB + sideC) / 2.0;
        double area = Math.Sqrt(halfPerimeter * 
            (halfPerimeter - sideA) * 
            (halfPerimeter - sideB) * 
            (halfPerimeter - sideC));
        Console.WriteLine(area);
    }
}

