using System;
using System.Diagnostics;
using System.Threading;

class FallingRocks
{
    static void Main()
    {
        //General Initialization

        Random rng = new Random();
        int[,] rockPositions = new int[30, 45]; 
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 60;
        var score = Stopwatch.StartNew();
        int playfield = 40;
        
        //Dwarf Initialization
        int dwarfX = playfield/2;
        int dwarfY = Console.WindowHeight-1;
        string dwarfSymbol = "(0)";
        ConsoleColor dwarfColor = ConsoleColor.Green;

        bool isGameOver = false;

        while (!isGameOver)
        {
            Console.Clear();
            dwarfX = KeyHandler(playfield, dwarfX);
            CreateRocks(rng, rockPositions, playfield);
            MoveRocksDown(rockPositions, playfield);

            bool isThereCollision;
            isThereCollision = CheckCollisions(rockPositions, playfield, dwarfX);
            PrintDwarf(dwarfX, dwarfY, dwarfSymbol, dwarfColor);
            PrintRocks(rng, rockPositions, playfield);
            ClearLastRow(rockPositions, playfield);
            DrawVerticalLines(playfield+1);
            DrawScore(score, playfield);
            SetDifficulty(score, playfield);
            isGameOver = GameOverLogic(score, isGameOver, isThereCollision);
        }
        Console.ReadLine();
    }

    private static bool GameOverLogic(Stopwatch score, bool isGameOver, bool isThereCollision)
    {
        if (isThereCollision)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Over \n\n Your Score is {0}\n\nThank you for playing. \n\nPress enter to Exit. \n\nYou suck", score.ElapsedMilliseconds / 10);
            isGameOver = true;
        }

        return isGameOver;
    }

    private static void SetDifficulty(Stopwatch score, int playfield)
    {
        if (score.ElapsedMilliseconds < 10000)
        {
            Console.SetCursorPosition(playfield + 1, 6);
            Console.Write("Difficulty:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Easy");
            Thread.Sleep(250);
        }
        else if (score.ElapsedMilliseconds < 15000)
        {
            Console.SetCursorPosition(playfield + 1, 6);
            Console.Write("Difficulty:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Medium");
            Thread.Sleep(150);
        }
        else if (score.ElapsedMilliseconds > 15000)
        {
            Console.SetCursorPosition(playfield + 1, 6);
            Console.Write("Difficulty:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Hard");
            Thread.Sleep(110);
        }
    }

    private static void DrawScore(Stopwatch score, int playfield)
    {
        Console.SetCursorPosition(playfield + 1, 3);
        Console.Write("Your Score: {0}", score.ElapsedMilliseconds / 10);
    }

    private static void DrawVerticalLines(int playfield)
    {
        for (int row = 0; row < 30; row++)
        {
            Console.SetCursorPosition(playfield, row);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
        }
    }

    private static void ClearLastRow(int[,] rockPositions, int playfield)
    {
        for (int col = 0; col < playfield; col++)
        {
            rockPositions[29, col] = 0;
        }
    }

    private static void PrintRocks(Random rng, int[,] rockPositions, int playfield)
    {
        for (int row = 0; row < 30; row++)
        {
            for (int col = 0; col < playfield; col++)
            {
                if (rockPositions[row, col] == 1)
                {
                    Console.SetCursorPosition(col,row);
                    Console.ForegroundColor = RandomiseColor(rng);
                    Console.Write("{0}", RandomiseRockSymbol(rng));
                }
            }
        }
    }

    private static void PrintDwarf(int dwarfX, int dwarfY, string dwarfSymbol, ConsoleColor dwarfColor)
    {
        Console.SetCursorPosition(dwarfX, dwarfY);
        Console.ForegroundColor = dwarfColor;
        Console.Write(dwarfSymbol);
    }

    private static bool CheckCollisions(int[,] rockPositions, int playfield, int dwarfX)
    {
        bool isThereCollision;
        int counter = 0;
        for (int col = 0; col < playfield; col++)
        {
            //Dwarf symbol is (0) and we need to check 3 positions
            bool hasDwarfBeenHit = (dwarfX == col || dwarfX + 1 == col || dwarfX + 2 == col);
            if (rockPositions[29, col] == 1 && hasDwarfBeenHit)
            {
                counter++;
            }
        }
        if (counter == 0)
        {
            isThereCollision = false;
        }
        else
        {
            isThereCollision = true;
        }

        return isThereCollision;
    }

    private static void MoveRocksDown(int[,] rockPositions, int playfield)
    {
        for (int row = 29; row >= 0; row--)
        {
            for (int col = 0; col < playfield; col++)
            {
                if (rockPositions[row, col] == 1)
                {
                    rockPositions[row, col] = 0;
                    rockPositions[row + 1, col] = 1;
                }
            }
        }
    }

    private static void CreateRocks(Random rng, int[,] rockPositions, int playfield)
    {
        int numberOfRocks = rng.Next(1, 4);
        for (int i = 0; i < numberOfRocks; i++)
        {
            int rockLength = rng.Next(1, 4);
            int positionX = rng.Next(0, playfield);
            for (int j = 0; j < rockLength; j++)
            {
                rockPositions[0, positionX + j] = 1;
            }

        }
    }

    private static int KeyHandler(int playfield, int dwarfX)
    {
        if (Console.KeyAvailable == true)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable) Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                //Move our character to the left. Check whether we've left the box
                if (dwarfX - 1 >= 0)
                {
                    dwarfX -= 2;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                //Move to the right -> Same as before
                if (dwarfX + 3 < playfield)
                {
                    dwarfX += 2;
                }
            }
        }

        return dwarfX;
    }

    private static char RandomiseRockSymbol(Random rng)
    {
        char[] rockSymbols = { '@','*','&','+','-','=','%','.', '$','/','!', 'ж'};
        int randomRockNumber = rng.Next(0,rockSymbols.Length);
        return rockSymbols[randomRockNumber];
    }

    private static ConsoleColor RandomiseColor(Random rng)
    {
        ConsoleColor[] colors = {ConsoleColor.Blue,ConsoleColor.Cyan, ConsoleColor.Yellow,
        ConsoleColor.Magenta, ConsoleColor.White,ConsoleColor.DarkYellow,ConsoleColor.Red };
        int randomColorNumber = rng.Next(0, colors.Length);
        return colors[randomColorNumber];
    }
}

