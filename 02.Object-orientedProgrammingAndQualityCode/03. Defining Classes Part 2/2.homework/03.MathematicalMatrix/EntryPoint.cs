namespace MathematicalMatrix
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            // Addition

            // int row = 3;
            // int col = 1;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 1;
            //m1Content[1, 0] = -1;
            //m1Content[2, 0] = 3;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = 2;
            //m2Content[1, 0] = 4;
            //m2Content[2, 0] = 8;

            // int row = 2;
            // int col = 3;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 1;
            //m1Content[0, 1] = -2;
            //m1Content[0, 2] = 0;
            //m1Content[1, 0] = 2;
            //m1Content[1, 1] = 1;
            //m1Content[1, 2] = -3;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = 2;
            //m2Content[0, 1] = 1;
            //m2Content[0, 2] = 3;
            //m2Content[1, 0] = -1;
            //m2Content[1, 1] = 1;
            //m2Content[1, 2] = -3;

            // int row = 3;
            // int col = 3;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 2;
            //m1Content[0, 1] = 3;
            //m1Content[0, 2] = 6;
            //m1Content[1, 0] = 1;
            //m1Content[1, 1] = 2;
            //m1Content[1, 2] = 3;
            //m1Content[2, 0] = -2;
            //m1Content[2, 1] = -3;
            //m1Content[2, 2] = 4;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = -1;
            //m2Content[0, 1] = 2;
            //m2Content[0, 2] = -3;
            //m2Content[1, 0] = 8;
            //m2Content[1, 1] = 4;
            //m2Content[1, 2] = 5;
            //m2Content[2, 0] = -5;
            //m2Content[2, 1] = 2;
            //m2Content[2, 2] = 3;

            //Matrix m1 = new Matrix(row, col, m1Content);
            //Matrix m2 = new Matrix(row, col, m2Content);

            //Matrix m3 = m1 + m2;

            // Subtraction

            //int row = 1;
            //int col = 3;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 9;
            //m1Content[0, 1] = 3;
            //m1Content[0, 2] = -2;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = -2;
            //m2Content[0, 1] = 8;
            //m2Content[0, 2] = -4;

            //int row = 2;
            //int col = 2;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 7;
            //m1Content[0, 1] = 6;
            //m1Content[1, 0] = -4;
            //m1Content[1, 1] = -1;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = -3;
            //m2Content[0, 1] = -2;
            //m2Content[1, 0] = 1;
            //m2Content[1, 1] = -3;

            //int row = 3;
            //int col = 3;
            //int[,] m1Content = new int[row, col];
            //m1Content[0, 0] = 9;
            //m1Content[0, 1] = 10;
            //m1Content[0, 2] = -7;
            //m1Content[1, 0] = 8;
            //m1Content[1, 1] = -4;
            //m1Content[1, 2] = 3;
            //m1Content[2, 0] = 1;
            //m1Content[2, 1] = 9;
            //m1Content[2, 2] = -3;

            //int[,] m2Content = new int[row, col];
            //m2Content[0, 0] = 3;
            //m2Content[0, 1] = 4;
            //m2Content[0, 2] = -1;
            //m2Content[1, 0] = -2;
            //m2Content[1, 1] = 1;
            //m2Content[1, 2] = 10;
            //m2Content[2, 0] = 7;
            //m2Content[2, 1] = 6;
            //m2Content[2, 2] = 5;

            //Matrix m3 = m1 - m2;

            // Multiplication

            //int row1 = 1;
            //int col1 = 3;
            //int[,] m1Content = new int[row1, col1];
            //m1Content[0, 0] = 1;
            //m1Content[0, 1] = 2;
            //m1Content[0, 2] = 3;

            //int row2 = 3;
            //int col2 = 1;
            //int[,] m2Content = new int[row2, col2];
            //m2Content[0, 0] = 4;
            //m2Content[1, 0] = -1;
            //m2Content[2, 0] = 2;

            //int row1 = 1;
            //int col1 = 2;
            //int[,] m1Content = new int[row1, col1];
            //m1Content[0, 0] = 1;
            //m1Content[0, 1] = 2;

            //int row2 = 2;
            //int col2 = 2;
            //int[,] m2Content = new int[row2, col2];
            //m2Content[0, 0] = 7;
            //m2Content[0, 1] = 3;
            //m2Content[1, 0] = -1;
            //m2Content[1, 1] = 2;

            //int row1 = 1;
            //int col1 = 1;
            //int[,] m1Content = new int[row1, col1];
            //m1Content[0, 0] = 2;

            //int row2 = 3;
            //int col2 = 2;
            //int[,] m2Content = new int[row2, col2];
            //m2Content[0, 0] = 2;
            //m2Content[0, 1] = 1;
            //m2Content[1, 0] = 3;
            //m2Content[1, 1] = 1;
            //m2Content[2, 0] = 1;
            //m2Content[2, 1] = 4;

            //int row1 = 1;
            //int col1 = 1;
            //int[,] m1Content = new int[row1, col1];
            //m1Content[0, 0] = -3;

            //int row2 = 3;
            //int col2 = 2;
            //int[,] m2Content = new int[row2, col2];
            //m2Content[0, 0] = -1;
            //m2Content[0, 1] = 2;
            //m2Content[1, 0] = 3;
            //m2Content[1, 1] = -4;
            //m2Content[2, 0] = 5;
            //m2Content[2, 1] = 6;

            int row1 = 2;
            int col1 = 2;
            int[,] m1Content = new int[row1, col1];
            m1Content[0, 0] = 1;
            m1Content[0, 1] = 3;
            m1Content[1, 0] = -2;
            m1Content[1, 1] = 2;

            int row2 = 2;
            int col2 = 2;
            int[,] m2Content = new int[row2, col2];
            m2Content[0, 0] = 2;
            m2Content[0, 1] = -1;
            m2Content[1, 0] = 1;
            m2Content[1, 1] = 3;

            Matrix m1 = new Matrix(row1, col1, m1Content);
            Matrix m2 = new Matrix(row2, col2, m2Content);

            Matrix m3 = m1 * m2;

            for (int i = 0; i < m3.Row; i++)
            {
                for (int j = 0; j < m3.Col; j++)
                {
                    Console.Write(m3.MatrixContent[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
