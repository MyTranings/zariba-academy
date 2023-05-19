using System;

class Game2048
{
    const int GAMEFIELD_SIZE = 4;
    const int UPPER_GAMEFIELD_LINE_POSITION = 3;
    const int DOWN_GAMEFIELD_LINE_POSITION = GAMEFIELD_SIZE + 9;

    static readonly Random rng = new Random();

    static void Main()
    {
        uint[,] gamefield = new uint[GAMEFIELD_SIZE, GAMEFIELD_SIZE];

        InitializeGamefield(gamefield);
        bool isGameOver = false;
        bool shouldGenerateNumber = false;

        int score = 0;
        int turns = 0;

        PrintUI();
        GenerateNumber(gamefield);

        while (!isGameOver)
        {
            GenerateNumber(gamefield, shouldGenerateNumber);

            PrintingGamefield(gamefield, score, turns);

            CalculatingScore(gamefield, out score);

            KeyHandling(gamefield, out shouldGenerateNumber);

            turns += CalculatingTurns(shouldGenerateNumber);

            isGameOver = CheckGameOverCondition(gamefield);
        }

        ShowGameOverScreen(score, turns);
    }

    private static int CalculatingTurns(bool shouldIncreaseTurnCount)
    {
        if (shouldIncreaseTurnCount)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private static void CalculatingScore(uint[,] gamefield, out int score)
    {
        score = 0;
        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            for (int j = 0; j < GAMEFIELD_SIZE; j++)
            {
                score += (int)gamefield[i, j];
            }
        }
    }

    private static void ShowGameOverScreen(int score, int turns)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("HAHA YOU DIED");

        Console.WriteLine();
        Console.WriteLine("Your score is {0} points", score);
        Console.WriteLine("You achieved that score in {0} turns", turns);
    }

    private static bool CheckGameOverCondition(uint[,] gamefield)
    {
        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            for (int j = 0; j < GAMEFIELD_SIZE; j++)
            {
                if (gamefield[i, j] == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static void KeyHandling(uint[,] gamefield, out bool hasMoved)
    {
        hasMoved = false;
        ConsoleKeyInfo keyPressed = Console.ReadKey();

        if (keyPressed.Key == ConsoleKey.LeftArrow)
        {
            MoveLeft(gamefield, out hasMoved);
        }
        else if (keyPressed.Key == ConsoleKey.RightArrow)
        {
            MoveRight(gamefield, out hasMoved);
        }
        else if (keyPressed.Key == ConsoleKey.DownArrow)
        {
            MoveDown(gamefield, out hasMoved);
        }
        else if (keyPressed.Key == ConsoleKey.UpArrow)
        {
            MoveUp(gamefield, out hasMoved);
        }
    }

    private static void MoveUp(uint[,] gamefield, out bool hasMoved)
    {
        hasMoved = false;
        for (int j = 0; j < GAMEFIELD_SIZE; j++)
        {
            for (int i = 0; i < GAMEFIELD_SIZE; i++)
            {
                for (int k = i + 1; k < GAMEFIELD_SIZE; k++)
                {
                    if (gamefield[k, j] == 0)
                    {
                        continue;
                    }
                    else if (gamefield[k, j] == gamefield[i, j])
                    {
                        gamefield[i, j] *= 2;
                        gamefield[k, j] = 0;
                        hasMoved = true;
                        break;
                    }
                    else
                    {
                        if (gamefield[i, j] == 0 && gamefield[k, j] != 0)
                        {
                            gamefield[i, j] = gamefield[k, j];
                            gamefield[k, j] = 0;
                            hasMoved = true;
                            i--;
                            break;
                        }
                        else if (gamefield[i, j] != 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void MoveDown(uint[,] gamefield, out bool hasMoved)
    {
        hasMoved = false;
        for (int j = 0; j < GAMEFIELD_SIZE; j++)
        {
            for (int i = GAMEFIELD_SIZE - 1; i >= 0; i--)
            {
                for (int k = i - 1; k >= 0; k--)
                {
                    if (gamefield[k, j] == 0)
                    {
                        continue;
                    }
                    else if (gamefield[k, j] == gamefield[i, j])
                    {
                        gamefield[i, j] *= 2;
                        gamefield[k, j] = 0;
                        hasMoved = true;
                        break;
                    }
                    else
                    {
                        if (gamefield[i, j] == 0 && gamefield[k, j] != 0)
                        {
                            gamefield[i, j] = gamefield[k, j];
                            gamefield[k, j] = 0;
                            hasMoved = true;
                            i++;
                            break;
                        }
                        else if (gamefield[i, j] != 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void MoveRight(uint[,] gamefield, out bool hasMoved)
    {
        hasMoved = false;
        // Rows
        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            // Columns
            for (int j = GAMEFIELD_SIZE - 1; j >= 0; j--)
            {
                // Helper
                for (int k = j - 1; k >= 0; k--)
                {
                    if (gamefield[i, k] == 0)
                    {
                        continue;
                    }
                    else if (gamefield[i, k] == gamefield[i, j])
                    {
                        gamefield[i, j] *= 2;
                        gamefield[i, k] = 0;
                        hasMoved = true;

                        break;
                    }
                    else
                    {
                        if (gamefield[i, j] == 0 && gamefield[i, k] != 0)
                        {
                            gamefield[i, j] = gamefield[i, k];
                            gamefield[i, k] = 0;
                            j++;
                            hasMoved = true;
                            break;
                        }
                        else if (gamefield[i, j] != 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void MoveLeft(uint[,] gamefield, out bool hasMoved)
    {
        hasMoved = false;
        // Rows
        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            // Columns
            for (int j = 0; j < GAMEFIELD_SIZE; j++)
            {
                // Helper
                for (int k = j + 1; k < GAMEFIELD_SIZE; k++)
                {
                    if (gamefield[i, k] == 0)
                    {
                        continue;
                    }
                    else if (gamefield[i, k] == gamefield[i, j])
                    {
                        gamefield[i, j] *= 2;
                        gamefield[i, k] = 0;
                        hasMoved = true;
                        break;
                    }
                    else
                    {
                        if (gamefield[i, j] == 0 && gamefield[i, k] != 0)
                        {
                            gamefield[i, j] = gamefield[i, k];
                            gamefield[i, k] = 0;
                            j--;
                            hasMoved = true;
                            break;
                        }
                        else if (gamefield[i, j] != 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void GenerateNumber(uint[,] gamefield, bool shouldGenerateNumber = true)
    {
        if (shouldGenerateNumber)
        {
            int x = rng.Next(0, GAMEFIELD_SIZE);
            int y = rng.Next(0, GAMEFIELD_SIZE);

            if (gamefield[x, y] == 0)
            {
                if (rng.Next(0, 10) == 9)
                {
                    gamefield[x, y] = 4;
                }
                else
                {
                    gamefield[x, y] = 2;
                }
            }
            else
            {
                GenerateNumber(gamefield);
            }
        }
    }

    private static void PrintingGamefield(uint[,] gamefield, int score, int turns)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(10, 0);
        Console.WriteLine(score);
        Console.SetCursorPosition(10, 2);
        Console.WriteLine(turns);

        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            Console.SetCursorPosition(12, i + 6);
            for (int j = 0; j < GAMEFIELD_SIZE; j++)
            {
                Coloring(i, j, gamefield);
                Console.Write("{0,5}", gamefield[i, j]);
            }
        }
    }

    private static void Coloring(int i, int j, uint[,] gamefield)
    {
        switch (gamefield[i, j])
        {
            case 0:
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                break;
            case 2:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                break;
            case 4:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                break;
            case 8:
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                break;

            case 16:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                break;
            case 32:
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                break;
            case 64:
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                break;
            case 128:
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                break;
            case 256:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                break;
            case 512:
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                break;
            case 1024:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                break;
            case 2048:
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                break;

        }
    }

    private static void PrintUI()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(3, 0);
        Console.WriteLine("Score: 0");
        Console.SetCursorPosition(3, 2);
        Console.WriteLine("Turns: 0");

        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.SetCursorPosition(i, UPPER_GAMEFIELD_LINE_POSITION);
            Console.WriteLine("-");

            Console.SetCursorPosition(i, DOWN_GAMEFIELD_LINE_POSITION);
            Console.WriteLine("-");
        }
    }

    private static void InitializeGamefield(uint[,] gamefield)
    {
        for (int i = 0; i < GAMEFIELD_SIZE; i++)
        {
            for (int j = 0; j < GAMEFIELD_SIZE; j++)
            {
                gamefield[i, j] = 0;
            }
        }
    }
}

