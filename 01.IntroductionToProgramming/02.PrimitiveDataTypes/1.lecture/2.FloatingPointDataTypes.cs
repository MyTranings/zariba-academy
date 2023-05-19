using System;

class FloatingPointDataTypes
{
    static void Main()
    {
        double firstNumber = 2.0;
        double secondNumber = 0.56;
        double sum = 2.56d;

        float anotherNumber = (float)2.0;

        Console.WriteLine("Sum of First and Second Number:"+sum);
        Console.WriteLine("First+Second Number:"+(firstNumber+secondNumber));

        decimal highPrecisionNumber = (decimal)2.0/7;
        Console.WriteLine(highPrecisionNumber);
    }
}

