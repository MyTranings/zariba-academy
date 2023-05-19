//11.* Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
//  n = 4
//1   2   3   4
//12  13  14  5
//11  16  15  6
//10  9   8   7

using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int maxNumber = n * n;

        int counter = 0;
        int curRow = 0;
        int curCol = 0;

        string direction = "right";

        while (counter < maxNumber)
        {
            if (direction == "right")
            {
                for (int col = curCol;  col < n; col++)
                {
                    if (matrix[curRow, col] != 0)
                    {
                        direction = "bottom";
                        curCol = col - 1;
                        curRow++;
                        break;
                    }
                    else 
                    {
                        counter++;
                        matrix[curRow, col] = counter;
                        if (col >= (n - 1))
                        {
                            direction = "bottom";
                            curCol = col;
                            curRow++;
                            break;
                        }
                    }
                }
            }

            if (direction == "bottom")
            {
                for (int row = curRow; row < n; row++)
                {
                    if (matrix[row, curCol] != 0)
                    {
                        direction = "left";
                        curRow = row - 1;
                        curCol--;
                        break;
                    }
                    else
                    {
                        counter++;
                        matrix[row, curCol] = counter;
                        if (row >= (n - 1))
                        {
                            direction = "left";
                            curRow = row;
                            curCol--;
                            break;
                        }
                    }
                }
            }

            if (direction == "left")
            {
                for (int col = curCol; col >= 0; col--)
                {
                    if (matrix[curRow, col] != 0)
                    {
                        direction = "up";
                        curCol = col + 1;
                        curRow--;
                        break;
                    }
                    else
                    {
                        counter++;
                        matrix[curRow, col] = counter;
                        if (col <= 0)
                        {
                            direction = "up";
                            curCol = col;
                            curRow--;
                            break;
                        }
                    }
                }
            }

            if (direction == "up")
            {
                for (int row = curRow; row >= 0; row--)
                {
                    if (matrix[row, curCol] != 0)
                    {
                        direction = "right";
                        curRow = row + 1;
                        curCol++;
                        break;
                    }
                    else
                    {
                        counter++;
                        matrix[row, curCol] = counter;
                        if (row <= 0)
                        {
                            direction = "right";
                            curRow = row;
                            curCol++;
                            break;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,2} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}