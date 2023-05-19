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

    // Type 1
    //public const int PLAYFIELD_WIDTH = 34;
    //public const int PLAYFIELD_HEIGHT = 27;
    // Type 2
    public const int PLAYFIELD_WIDTH = 40;
    public const int PLAYFIELD_HEIGHT = 33;
    // Type 3
    //public const int PLAYFIELD_WIDTH = 46;
    //public const int PLAYFIELD_HEIGHT = 39;

    public const int PLAYFIELD_MAX_WIDTH = PLAYFIELD_WIDTH - 1;
    public const int PLAYFIELD_MAX_HEIGHT = PLAYFIELD_HEIGHT - 1;
    public const int BOX_SIZE = 3;

    public static int PLAYFIELD_WIDTH_BORDER = 1;
    public static int PLAYFIELD_HEIGHT_BORDER = 1;

    public const int PLAYFIELD_ROWS = PLAYFIELD_HEIGHT / BOX_SIZE;
    public const int PLAYFIELD_COLS = PLAYFIELD_MAX_WIDTH / BOX_SIZE;

    static void Main()
    {
        // Initilize playfield
        Console.BufferWidth = Console.WindowWidth = PLAYFIELD_WIDTH + 100;
        Console.BufferHeight = Console.WindowHeight = PLAYFIELD_HEIGHT;
        int[,] playfield = new int[PLAYFIELD_HEIGHT, PLAYFIELD_MAX_WIDTH];

        // Initizlize level
        int lvlNumber = 1;
        int lvlType = 2;

        Random rnd = new Random();
        int subLevel = rnd.Next(1, 3);

        string fileName = GetFileName(Convert.ToString(lvlNumber), Convert.ToString(lvlType), subLevel);
        string input = File.ReadAllText(fileName);

        int[,] level = BuildLevel(input);

        List<List<int>> emptyBoxes;
        emptyBoxes = GetEmptyBoxes(level);

        int[] playerPositionGameGrid = new int[2];

        List<Position> playerPosition = PlayerInitialization(subLevel, ref playerPositionGameGrid);
        DrawPlayer(playerPosition);

        int numberOfBlocks = 50;

        DrawLevel(level);
        DrawBreakableBlock(level, emptyBoxes, numberOfBlocks);
    }

    private static void DrawPlayer(List<Position> playerPosition)
    {
        foreach (Position bodyPart in playerPosition)
        {
            Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
            Console.Write(bodyPart.Symbol);
        }
    }

    private static List<Position> PlayerInitialization(int subLevel, ref int[] playerPositionGameGrid)
    {
        List<Position> playerPosition = new List<Position>();
        int x = (PLAYFIELD_WIDTH / PLAYFIELD_WIDTH) + (PLAYFIELD_WIDTH_BORDER * BOX_SIZE) - 1;
        int y = (PLAYFIELD_HEIGHT / PLAYFIELD_HEIGHT) + (PLAYFIELD_HEIGHT_BORDER * BOX_SIZE) - 1;

        if (subLevel == 2)
        {
            x += BOX_SIZE;
        }

        playerPositionGameGrid[0] = x / BOX_SIZE;
        playerPositionGameGrid[1] = y / BOX_SIZE;

        playerPosition.Add(new Position(x + 1, y, 'O'));
        playerPosition.Add(new Position(x, y + 1, '/'));
        playerPosition.Add(new Position(x + 1, y + 1, '|'));
        playerPosition.Add(new Position(x + 2, y + 1, '\\'));
        playerPosition.Add(new Position(x, y + 2, '/'));
        playerPosition.Add(new Position(x + 2, y + 2, '\\'));

        return playerPosition;
    }

    private static void DrawBreakableBlock(int[,] level, List<List<int>> emptyBoxes, int iterations)
    {
        Random rnd = new Random();

        while (iterations > 0)
        {

            int rndRow = rnd.Next(emptyBoxes.Count);
            int rndColIndex = rnd.Next(emptyBoxes[rndRow].Count);
            int matrixRow = rndRow + PLAYFIELD_HEIGHT_BORDER;
            int matrixCol = emptyBoxes[rndRow][rndColIndex];

            if (PLAYFIELD_WIDTH_BORDER > 0)
            {
                matrixCol -= 1;
            }

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
    
    private static string GetFileName(string nextLvl, string lvlType, int subLevel)
    {
        string fileName = "level" + nextLvl + "-type" + lvlType;

        if (subLevel == 1)
        {
            fileName += "-1.txt";
        }
        else
        {
            fileName += "-2.txt";
        }
        
        return fileName;
    }
}