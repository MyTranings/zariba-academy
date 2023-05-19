using System;

class NestedLoops
{
    static void Main()
    {
        //We would like to create the following triangle for different values of n
        // In this case n=6;
        // 1
        // 1 2
        // 1 2 3
        // 1 2 3 4
        // 1 2 3 4 5
        // 1 2 3 4 5 6

        int n = int.Parse(Console.ReadLine());

        for (int row = 1; row <= n; row++)
        {
            for (int number = 1; number <= row; number++)
            {
                Console.Write("{0} ",number);
            }
            Console.WriteLine();
        }
    }   
}       
