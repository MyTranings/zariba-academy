using System;

class TrianglePrint
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int numbersOnALine = 1; numbersOnALine <= n; numbersOnALine++)
        {
            PrintLine(1, numbersOnALine);
            Console.WriteLine();
        }
        for (int i = n-1; i >= 1; i--)
        {
            PrintLine(1, i);
            Console.WriteLine();
        }

        PrintNumbers(1, 10);
        Console.WriteLine();
        PrintNumbers();
        Console.WriteLine();
        PrintNumbers(end:15);

    }
    static void PrintLine(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write(" {0}",i);
        }
    }
    //Optional Parameters
    static void PrintNumbers(int start=1, int end=30)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write("{0} ",i);
        }
    }
}

