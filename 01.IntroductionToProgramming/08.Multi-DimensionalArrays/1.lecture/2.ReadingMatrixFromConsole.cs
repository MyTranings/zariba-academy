using System;

class ReadingMatrix
{
    static void Main()
    {
        //Reading a matrix from the Console #1
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("matrix[{0},{1}]=", row, col);
                //matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }

        int[,] secondMatrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string currentRow = Console.ReadLine();
            string[] numbersAsStringArray = currentRow.Split(' ');
            for (int col = 0; col < cols; col++)
            {
                secondMatrix[row, col] = int.Parse(numbersAsStringArray[col]);
            }
        }
        Console.WriteLine("\n");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0} ", secondMatrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    //Read from the console this:
    //1 2 3 0    "1 2 3" ->{"1", "2", "3"}
    //4 5 6 -1
    //7 8 9 5
}

