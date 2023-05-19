//10.  Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
//n = 3 				n = 4
//      1  2  3                        1  2  3  4 
//      2  3  4                        2  3  4  5 
//      3  4  5                        3  4  5  6  
//		                		       4  5  6  7

using System;

class NToMatrix
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        for (int row = 0; row < n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                Console.Write("{0} ", row + col);
            }
            Console.WriteLine();
        }
    }
}
