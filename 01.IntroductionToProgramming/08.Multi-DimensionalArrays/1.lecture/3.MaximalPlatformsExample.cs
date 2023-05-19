using System;

class MaximalPlatform
{
    static void Main()
    {
        //We read a matrix from the console 
        // and we want to find the maximal 2x2 sum of the matrix.
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string currentRow = Console.ReadLine();
            string[] numbersAsStringArray = currentRow.Split(' ');
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = int.Parse(numbersAsStringArray[col]);
            }
        }
        // 1 2 6 4 5
        // 2 1 0 0 6
        // 2 4 5 6 1
        long maximalSum = Int64.MinValue;

        for (int i = 0; i < rows-1; i++)
        {
            for (int j = 0; j < cols-1; j++)
            {
                long tempSum = matrix[i, j] + matrix[i + 1, j] + 
                    matrix[i, j + 1] + matrix[i + 1, j + 1];

                if (tempSum>maximalSum)
                {
                    maximalSum = tempSum;
                }
            }
        }
        Console.WriteLine("The maximum 2x2 sum is {0}",maximalSum);
    }
}

