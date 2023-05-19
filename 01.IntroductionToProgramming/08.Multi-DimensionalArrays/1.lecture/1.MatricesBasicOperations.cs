using System;

class MatricesDemo
{
    static void Main()
    {
        //Initialization
        int[,] intMatrix = new int[2, 3];
        float[,] floatMatrix = new float[3, 5];
        string[,,] stringCube = new string[3, 4, 5];

        int[,] someNumbersInAMatrix = {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        //Accessing Elements
        Console.WriteLine(someNumbersInAMatrix[1, 1]);
        Console.WriteLine(someNumbersInAMatrix[0, 2]);

        //Lengths
        Console.WriteLine("Number of elements {0}", someNumbersInAMatrix.Length);

        for (int row = 0; row < someNumbersInAMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < someNumbersInAMatrix.GetLength(1); col++)
            {
                someNumbersInAMatrix[row, col] = row + col;
            }
        }
        Console.WriteLine("\n\n");

        //Printing a two dimensional Array 
        for (int i = 0; i < someNumbersInAMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < someNumbersInAMatrix.GetLength(1); j++)
            {
                Console.Write("{0} ",someNumbersInAMatrix[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(string.Join(", ", someNumbersInAMatrix));
    }
}

