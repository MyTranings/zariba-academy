using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class CleanBomberMan
{
    struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Position(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }
    }

    public const int PLAYFIELD_WIDTH = 34;
    public const int PLAYFIELD_HEIGHT = 27;
    public const int PLAYFIELD_WIDTH1 = 40;
    public const int PLAYFIELD_HEIGHT1 = 39;
    public const int PLAYFIELD_MAX_WIDTH = PLAYFIELD_WIDTH - 1;
    public const int PLAYFIELD_MAX_HEIGHT = PLAYFIELD_HEIGHT - 1;
    public const int BOX_SIZE = 3;

    public const int PLAYFIELD_WIDTH_BORDER = 0;
    public const int PLAYFIELD_HEIGHT_BORDER = 0;

    public const int PLAYFIELD_ROWS = PLAYFIELD_HEIGHT / BOX_SIZE;
    public const int PLAYFIELD_COLS = PLAYFIELD_MAX_WIDTH / BOX_SIZE;

    static void Main()
    {
        Random rnd = new Random();
        // Initilize playfield
        Console.BufferWidth = Console.WindowWidth = PLAYFIELD_WIDTH + 100;
        Console.BufferHeight = Console.WindowHeight = PLAYFIELD_HEIGHT;
        int[,] playfield = new int[PLAYFIELD_HEIGHT, PLAYFIELD_MAX_WIDTH];

        // Initizlize level
        int levelType = rnd.Next(1, 2);
        LevelType(levelType);


        string input = File.ReadAllText("leveltest.txt");

        int[,] level = BuildLevel(input);

        List<List<int>> emptyBoxes;
        emptyBoxes = GetEmptyBoxes(level);

        int[,] playerPosition = new int[1, 1];

        int numberOfBlocks = 50;

        DrawLevel(level);
        DrawBreakableBlock(level, emptyBoxes, numberOfBlocks);
    }

    private static void DrawBreakableBlock(int[,] level, List<List<int>> emptyBoxes, int iterations)
    {
        Random rnd = new Random();

        while (iterations > 0)
        {

            int rndRow = rnd.Next(emptyBoxes.Count);
            int rndColIndex = rnd.Next(emptyBoxes[rndRow].Count);
            int matrixRow = rndRow + PLAYFIELD_HEIGHT_BORDER;
            int matrixCol = emptyBoxes[rndRow][rndColIndex] - PLAYFIELD_WIDTH_BORDER;

            int cursorPositionTop = matrixRow * BOX_SIZE;
            for (int i = BOX_SIZE - 1; i >= 0; i--)
            {
                int cursorPositionLeft = matrixCol * BOX_SIZE;
                for (int j = BOX_SIZE - 1; j >= 0; j--)
                {
                    level[cursorPositionTop, cursorPositionLeft] = '2';
                    Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);
                    Console.Write('2');
                    cursorPositionLeft++;
                }
                cursorPositionTop++;
            }
            emptyBoxes[rndRow].Remove(rndColIndex);
            iterations--;
        }
    }

    // Works without border
    //private static void DrawBreakableBlock(int[,] level, List<List<int>> emptyBoxes, int iterations)
    //{
    //    Random rnd = new Random();

    //    while (iterations > 0)
    //    {
    //        int rndRow = rnd.Next(1, PLAYFIELD_ROWS);
    //        int rndCol = rnd.Next(1, PLAYFIELD_COLS);
    //        //int rndRow = 11;
    //        //int rndCol = 13;

    //        if (emptyBoxes.Count >= rndRow)
    //        {
    //            if (emptyBoxes[rndRow - 1].Contains(rndCol - 1))
    //            {
    //                emptyBoxes[rndRow - 1].Remove(rndCol - 1);

    //                int cursorPositionTop = (rndRow - 1) * BOX_SIZE;

    //                for (int i = BOX_SIZE - 1; i >= 0; i--)
    //                {
    //                    int cursorPositionLeft = (rndCol - 1) * BOX_SIZE;
    //                    for (int j = BOX_SIZE - 1; j >= 0; j--)
    //                    {
    //                        level[cursorPositionTop, cursorPositionLeft] = '2';
    //                        Console.SetCursorPosition(cursorPositionLeft, cursorPositionTop);
    //                        Console.Write('2');
    //                        cursorPositionLeft++;
    //                    }
    //                    cursorPositionTop++;
    //                }
    //                iterations--;
    //            }
    //            else
    //            {
    //                rndCol = rnd.Next(0, PLAYFIELD_COLS);
    //            }
    //        }
    //        else
    //        {
    //            rndRow = rnd.Next(0, PLAYFIELD_ROWS);
    //        }
    //    }
    //}

    private static List<List<int>> GetEmptyBoxes(int[,] level)
    {
        IEnumerable<int> bufferList = new List<int>();
        List<int> emptyInCurRow = new List<int>();
        List<int> numberOfEmptyBoxesPerRow = new List<int>();
        List<List<int>> numberOfEmptyBoxes = new List<List<int>>();

        int box = 0;
        int countZeroCol = 0;

        for (int row = 0; row < level.GetLength(0); row++)
        {
            countZeroCol = 0;
            emptyInCurRow.Clear();

            for (int col = 0; col < level.GetLength(1); col++)
            {
                if (level[row, col] == 1)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write('*');
                    if (countZeroCol > 0)
                    {
                        countZeroCol -= BOX_SIZE;
                    }
                }
                else if (level[row, col] == 0)
                {
                    countZeroCol++;
                }
                else
                {
                    if (countZeroCol >= 0)
                    {
                        countZeroCol -= BOX_SIZE;
                    }
                }

                if (countZeroCol > 0 && countZeroCol % 3 == 0)
                {
                    box = (col + PLAYFIELD_WIDTH_BORDER) / BOX_SIZE;
                    emptyInCurRow.Add(box);
                    countZeroCol = 0;
                }
            }

            if (!numberOfEmptyBoxesPerRow.Any())
            {
                numberOfEmptyBoxesPerRow.AddRange(emptyInCurRow);
            }
            else
            {
                bufferList = numberOfEmptyBoxesPerRow.Intersect(emptyInCurRow);
                numberOfEmptyBoxesPerRow = bufferList.ToList();

                if ((row + 1) % BOX_SIZE == 0)
                {
                    numberOfEmptyBoxes.Add(new List<int>(numberOfEmptyBoxesPerRow));
                    numberOfEmptyBoxesPerRow.Clear();
                }
            }
        }

        return numberOfEmptyBoxes;
    }

    private static void DrawLevel(int[,] level)
    {
        for (int row = 0; row < level.GetLength(0); row++)
        {
            for (int col = 0; col < level.GetLength(1); col++)
            {
                if (level[row, col] == 1)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write('*');
                }
            }
        }
    }

    private static int[,] BuildLevel(string input)
    {
        int i = 0,
            j = 0;
        int[,] level = new int[PLAYFIELD_HEIGHT, PLAYFIELD_MAX_WIDTH];
        string[] newLinesSeparators = new string[] { "\r", "\n", "\r\n" };

        foreach (string row in input.Trim().Split('\n'))
        {
            j = 0;
            foreach (string col in row.Trim().Split(' '))
            {
                level[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }

        return level;
    }

    private static void LevelType(int n)
    {
        if (n == 1)
        {
            Console.WriteLine("Level type with first el is blocked");
        }
        else if (n == 2)
        {
            Console.WriteLine("Level type with first el free");
        }
    }
}