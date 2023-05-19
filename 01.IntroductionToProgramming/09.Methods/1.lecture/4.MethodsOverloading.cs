using System;

class Overloading
{
    static void Main()
    {
        int[] array = { 1, 2, -2, 4, 5 };
        Print("Zariba Academy");
        Print(5);
        Array.Sort(array);
        Print(array);
        Console.WriteLine(CalculateSum(1));
        Console.WriteLine(CalculateSum(1, 2));
        Console.WriteLine(CalculateSum(1, 2, 3, 4, 5));
        Console.WriteLine(CalculateSum());
    }
    static void Print(string text)
    {
        Console.WriteLine(text);
    }
    static void Print(int number)
    {
        Console.WriteLine(number);
    }
    static void Print(int[] array)
    {
        Console.WriteLine(string.Join(", ",array));
    }
    
    //Variable Number of Parameters
    static long CalculateSum(params int[] elements)
    {
        long sum = 0;
        foreach (var number in elements)
        {
            sum += number;
        }
        return sum;
    }
}

