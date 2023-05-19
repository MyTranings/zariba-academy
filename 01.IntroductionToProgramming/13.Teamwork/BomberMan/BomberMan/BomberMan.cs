using System;
using System.Collections.Generic;
using System.IO;

struct Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }

    public Position( int x, int y, char symbol )
    {
        this.X = x;
        this.Y = y;
        this.Symbol = symbol;
    }
}

public class BomberMan
{
    // Initialize the playfield size
    public const int PLAYFIELD_WIDTH = 33;
    public const int PLAYFIELD_HEIGHT = 40;
    public const int PLAYFIELD_MAX_WIDTH = PLAYFIELD_HEIGHT - 1;

    public const int boxWidth = 3;
    public const int boxHeight = 3;

    static void Main()
    {
        // Initialize the playfield
        Console.BufferHeight = Console.WindowHeight = PLAYFIELD_HEIGHT;
        Console.BufferWidth = Console.WindowWidth = PLAYFIELD_WIDTH + 20;

        //int[,] playfield = new int[PLAYFIELD_HEIGHT, PLAYFIELD_WIDTH];
        int[,] playfield = new int[PLAYFIELD_WIDTH, PLAYFIELD_HEIGHT]; // Obratno sa
        
        // Read level
        String input = File.ReadAllText("level01.txt");

        int[,] level = LoadLevel(input);

        // Init Player
        List<Position> playerPosition;
        playerPosition = PlayerInitialization(PLAYFIELD_WIDTH, PLAYFIELD_HEIGHT);

    }

    private static List<Position> PlayerInitialization(int pLAYFIELD_WIDTH, int pLAYFIELD_HEIGHT)
    {
        List<Position> playerPosition = new List<Position>();
        
        return playerPosition;
    }

    //private static List<EmptyBoxes> DrawLevel(int[,] level)
    private static void DrawLevel(int[,] level)
    {
        //List<EmptyBoxes> emptyBoxes = new List<EmptyBoxes>();

        for (int row = 0; row < PLAYFIELD_WIDTH; row++)
        {
            for (int col = 0; col < PLAYFIELD_HEIGHT; col++)
            {
                if (level[row, col] == 1)
                {
                    Console.SetCursorPosition(row, col);
                    Console.WriteLine('*');
                }
                //else if (level[row, col] == 0)
                //{
                    //emptyBoxes.Add(new EmptyBoxes(row, col, char.Parse(level[row, col].ToString())));
                //}
            }
        }

        //return emptyBoxes;
    }

    private static int[,] LoadLevel(string input)
    {
        int i = 0,
            j = 0;
        int[,] level = new int[PLAYFIELD_WIDTH, PLAYFIELD_HEIGHT];

        foreach (string row in input.Split('\n'))
        {
            j = 0;
            foreach (string symbol in row.Trim().Split(' '))
            {
                level[i, j] = int.Parse(symbol.Trim());
                j++;
            }
            i++;
        }

        return level;
    }
}