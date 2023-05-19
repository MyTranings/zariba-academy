using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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


class AllahuAcbar
{
    static void Main()
    {
        //Initialize the playfield
        int playfieldHeight = 33;
        int playfieldWidth = 40;
        Console.BufferHeight = Console.WindowHeight = playfieldHeight;
        Console.BufferWidth = Console.WindowWidth = playfieldWidth + 20;
        int[,] playfield = new int[playfieldHeight, playfieldWidth];

        //Load the level
        String input = File.ReadAllText("Level01.txt");

        int[,] level = LoadLevel(input);

        //initialize the player

        List<Position> playerPositions;
        playerPositions = PlayerInitialization(playfieldHeight, playfieldWidth);
        int lives = 3;


        //bomb stuff
        bool canPlaceBomb = true;



        bool isGameOver = false;
        while (!isGameOver)
        {
            Console.Clear();
            KeyHandler(level, playerPositions, ref canPlaceBomb);
            HorizontalEnemyMovement(level);
            VerticalEnemyMovement(level);
            DrawPlayer(playerPositions);
            DrawLevel(level);
            Thread.Sleep(100);

        }

        Console.ReadKey();
    }

    private static void VerticalEnemyMovement(int[,] level)
    {
        for (int i = 3; i < level.GetLength(0) - 3; i++)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (level[i - 3, j] == 0)
                {
                    if (level[i, j] == 6)
                    {
                        level[i - 3, j] = 6;
                        level[i, j] = 0;
                    }
                }
                else if (level[i - 3, j] > 0)
                {
                    if (level[i - 3, j] == 6)
                    {
                        level[i - 3, j] = 7;

                    }
                }
            }
        }
        for (int i = level.GetLength(0) - 4; i > 0; i--)
        {
            for (int j = 0; j < level.GetLength(1); j++)
            {
                if (level[i + 3, j] == 0)
                {
                    if (level[i, j] == 7)
                    {
                        level[i + 3, j] = 7;
                        level[i, j] = 0;
                    }
                }
                else if (level[i + 3, j] > 0)
                {
                    if (level[i + 3, j] == 7)
                    {
                        level[i + 3, j] = 6;

                    }
                }
            }
        }
    }

    private static void HorizontalEnemyMovement(int[,] level)
    {
        //enemyX movement
        for (int j = 3; j < level.GetLength(1) - 3; j++)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                if (level[i, j - 3] == 0)
                {
                    if (level[i, j] == 4)
                    {
                        level[i, j - 3] = 4;
                        level[i, j] = 0;
                    }
                }
                else if (level[i, j - 3] > 0)
                {
                    if (level[i, j - 3] == 4)
                    {
                        level[i, j - 3] = 5;

                    }
                }
            }
        }
        for (int j = level.GetLength(1) - 4; j > 0; j--)
        {
            for (int i = 0; i < level.GetLength(0); i++)
            {
                if (level[i, j + 3] == 0)
                {
                    if (level[i, j] == 5)
                    {
                        level[i, j + 3] = 5;
                        level[i, j] = 0;
                    }
                }
                else if (level[i, j + 3] > 0)
                {
                    if (level[i, j + 3] == 5)
                    {
                        level[i, j + 3] = 4;

                    }
                }
            }
        }
    }

    private static void KeyHandler(int[,] level, List<Position> playerPositions, ref bool canPlaceBomb)
    {
        if (Console.KeyAvailable)
        {
            //hack
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable) Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (level[playerPositions[0].X + 1, playerPositions[0].Y - 3] == 0)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X, playerPositions[i].Y - 3, playerPositions[i].Symbol);
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (level[playerPositions[0].X + 1, playerPositions[0].Y + 3] == 0)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X, playerPositions[i].Y + 3, playerPositions[i].Symbol);
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (level[playerPositions[0].X + 4, playerPositions[0].Y] == 0)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X + 3, playerPositions[i].Y, playerPositions[i].Symbol);
                    }
                }
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (level[playerPositions[0].X - 2, playerPositions[0].Y] == 0)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X - 3, playerPositions[i].Y, playerPositions[i].Symbol);
                    }
                }
            }
            if (canPlaceBomb == true)

            {
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    level[playerPositions[0].X + 1, playerPositions[0].Y] = 3;
                    canPlaceBomb = false;
                }

            }
        }
    }

    private static int[,] LoadLevel(string input)
    {
        int i = 0, j = 0;
        int[,] level = new int[33, 39];
        foreach (var row in input.Split('\n'))
        {
            j = 0;
            foreach (var col in row.Trim().Split(' '))
            {
                level[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }

        return level;
    }

    private static void DrawPlayer(List<Position> playerPositions)
    {
        foreach (Position bodyPart in playerPositions)
        {
            Console.SetCursorPosition(bodyPart.Y, bodyPart.X);
            Console.Write(bodyPart.Symbol);
        }
    }

    private static List<Position> PlayerInitialization(int playfieldHeight, int playfieldWidth)
    {
        List<Position> playerPositions = new List<Position>();
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 2, playfieldWidth / playfieldWidth + 3, 'O'));
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 3, playfieldWidth / playfieldWidth + 3, '|'));
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 3, playfieldWidth / playfieldWidth + 2, '/'));
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 3, playfieldWidth / playfieldWidth + 4, '\\'));
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 4, playfieldWidth / playfieldWidth + 2, '/'));
        playerPositions.Add(new Position(playfieldHeight / playfieldHeight + 4, playfieldWidth / playfieldWidth + 4, '\\'));
        return playerPositions;
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
                else if (level[row, col] == 3)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write('O');
                }
                else if (level[row, col] == 4 || level[row, col] == 5 || level[row, col] == 6 || level[row, col] == 7)
                {
                    Console.SetCursorPosition(col - 1, row);
                    Console.Write("_O_");
                }
            }
        }
    }
}