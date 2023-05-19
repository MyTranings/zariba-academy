using System;
using System.Threading;
using System.IO;

namespace Arkanoid
{
    class Arkanoid
    {
        static void Main()
        {
            //General Initialization
            int playfieldHeight = 40;
            int playfieldWidth = 90;
            Console.BufferHeight = Console.WindowHeight = playfieldHeight;
            Console.BufferWidth = Console.WindowWidth = playfieldWidth + 20;
            bool isGameOver = false;

            //Platform Initialization
            int platformX = playfieldWidth / 2;
            int platformY = playfieldHeight - 1;
            string platformSymbol = "(################)";
            int platformWidth = 18;
            ConsoleColor platformColor = ConsoleColor.Red;

            //Ball Initialization
            int ballX = platformX + platformWidth / 2;
            int ballY = platformY - 2;
            bool isBallLaunched = false;
            int velocityX = -1, velocityY = 1;

            //BrickInitialization
            int[,] brickPositions = new int[playfieldHeight, playfieldWidth];
            int bricksDestroyed = 0;

            DrawWallBounds(playfieldWidth, playfieldHeight);
            DrawWallBounds(0, playfieldHeight);
            DrawCeilingBounds(playfieldWidth);
            LevelLoader(brickPositions);
            PrintBricks(brickPositions);

            while (!isGameOver)
            {
                platformSymbol = SetDifficulty(playfieldWidth, bricksDestroyed, platformSymbol, ref platformWidth, platformX);
                platformX = KeyHandler(playfieldWidth, playfieldHeight, platformX, platformWidth, ref isBallLaunched);
                MoveBall(ref ballX, ref ballY, playfieldWidth, platformX, platformWidth, ref velocityX, ref velocityY, isBallLaunched);
                PrintPlatform(platformX, platformY, platformSymbol, platformColor);
                PrintBall(ballX, ballY);
                velocityY = CollisionWithBricks(brickPositions, ref bricksDestroyed, velocityY, ballX, ballY);
                velocityY = CollisionWithPlatform(platformX, platformWidth, velocityY, ballX, ballY, playfieldHeight);
                isGameOver = FloorHit(ballX, ballY);
            }
            GameOverScreen(bricksDestroyed, isGameOver);
            Console.ReadLine();
        }

        private static void GameOverScreen(int bricksDestroyed, bool isGameOver)
        {
            if(isGameOver)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game Over \n\nYour score is {0}\n\nThank you for playing\n\n",bricksDestroyed);
            }
        }

        private static bool FloorHit(int ballX, int ballY)
        {
            if(ballY == 39)
            {
                return true;
            }
            return false;
        }

        private static string SetDifficulty(int playfieldWidth, int bricksDestroyed, string platformSymbol, ref int platformWidth, int platformX)
        {
            bool difficultyChanged = false;
            if(bricksDestroyed<=5)
            {
                Console.SetCursorPosition(playfieldWidth + 2, 6);
                Console.Write("Difficulty: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Easy");
                Thread.Sleep(80);
            }
            else if(bricksDestroyed>5 && bricksDestroyed <=15)
            {
                difficultyChanged = true;
                platformSymbol = "(############)";
                Console.SetCursorPosition(playfieldWidth + 2, 6);
                Console.Write("Difficulty: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Medium");
                Thread.Sleep(40);
            }
            else if (bricksDestroyed > 15 && bricksDestroyed <=25 )
            {
                difficultyChanged = true;
                platformSymbol = "(########)";
                Console.SetCursorPosition(playfieldWidth + 2, 6);
                Console.Write("Difficulty: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Hard  ");
                Thread.Sleep(20);
            }
            else if (bricksDestroyed > 25)
            {
                difficultyChanged = true;
                platformSymbol = "(##)";
                Console.SetCursorPosition(playfieldWidth + 2, 6);
                Console.Write("Difficulty: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Insane");
                Thread.Sleep(7);
            }
            if(difficultyChanged == true)
            {
                Console.SetCursorPosition(platformX, 39);
                Console.Write(new string (' ', platformWidth));
            }

            platformWidth = platformSymbol.Length;
            return platformSymbol;
        }

        private static int CollisionWithBricks(int[,] brickPositions, ref int bricksDestroyed, int velocityY, int ballX, int ballY)
        {
            for (int row = 0; row < brickPositions.GetLength(0); row++)
            {
                for (int col = 0; col < brickPositions.GetLength(1); col++)
                {
                    if (ballX == col && ballY == row && brickPositions[row, col] != 0)
                    {
                        bricksDestroyed++;
                        velocityY = -velocityY;
                        int counter = 0;
                        while (brickPositions[row, col - counter] != 0)
                        {
                            Console.SetCursorPosition(col - counter, row);
                            brickPositions[row, col - counter] = 0;
                            Console.Write(" ");
                            counter++;
                        }
                        counter = 1;
                        while (brickPositions[row, col + counter] != 0)
                        {
                            Console.SetCursorPosition(col + counter, row);
                            brickPositions[row, col + counter] = 0;
                            Console.Write(" ");
                            counter++;
                        }
                    }
                }
            }
            return velocityY;
        }

        private static int CollisionWithPlatform(int platformX, int platformWidth, int velocityY, int ballX, int ballY, int playfieldHeight)
        {
            if (ballY == playfieldHeight - 2)
            {
                for (int i = platformX; i < platformX + platformWidth; i++)
                {
                    if (ballX == i)
                    {
                        velocityY = -velocityY;
                    }
                }
            }
            return velocityY;
        }

        private static void MoveBall(ref int ballX, ref int ballY, int playfieldWidth, int platformX,
            int platformWidth, ref int velocityX, ref int velocityY, bool isBallLaunched)
        {
            Console.SetCursorPosition(ballX, ballY);
            Console.Write(" ");
            if (isBallLaunched)
            {
                if (ballX == playfieldWidth - 1 || ballX == 1)
                {
                    velocityX = -velocityX;
                }
                if (ballY == 1)
                {
                    velocityY = -velocityY;
                }
                ballY -= velocityY;
                ballX -= velocityX;
            }
            else
            {
                ballX = platformX + platformWidth / 2;
            }
        }

        private static void PrintBricks(int[,] brickPositions)
        {
            for (int row = 0; row < brickPositions.GetLength(0); row++)
            {
                for (int col = 0; col < brickPositions.GetLength(1); col++)
                {
                    if (brickPositions[row, col] == 1)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                    }
                    if (brickPositions[row, col] == 2)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("#");
                    }
                    if (brickPositions[row, col] == 3)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("@");
                    }
                }
            }
        }

        private static void LevelLoader(int[,] brickPositions)
        {
            string[] input = File.ReadAllLines("level1.txt");

            for (int row = 0; row < input.Length; row++)
            {
                string[] inputLinesArray = input[row].Split(' ');
                for (int col = 0; col < brickPositions.GetLength(1); col++)
                {
                    brickPositions[row, col] = int.Parse(inputLinesArray[col]);
                }
            }
        }

        private static void DrawCeilingBounds(int playfieldWidth)
        {
            for (int col = 1; col < playfieldWidth; col++)
            {
                Console.SetCursorPosition(col, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("-");
            }
        }

        private static void DrawWallBounds(int playfieldWidth, int playfieldHeight)
        {
            for (int row = 0; row < playfieldHeight - 1; row++)
            {
                Console.SetCursorPosition(playfieldWidth, row);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
            }
        }

        private static void PrintBall(int ballX, int ballY)
        {
            Console.SetCursorPosition(ballX, ballY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("O");
        }

        private static int KeyHandler(int playfieldWidth, int playfieldHeight, int platformX, int platformWidth, ref bool isBallLaunched)
        {
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                Console.SetCursorPosition(platformX, playfieldHeight - 1);
                Console.Write(new string(' ', platformWidth));

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (platformX - 2 > 0)
                    {
                        platformX -= 4;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (platformX + platformWidth < playfieldWidth)
                    {
                        platformX += 4;
                    }
                }
                if (pressedKey.Key == ConsoleKey.Spacebar && isBallLaunched == false)
                {
                    isBallLaunched = true;
                }
            }
            return platformX;
        }

        private static void PrintPlatform(int platformX, int platformY,
            string platformSymbol, ConsoleColor platformColor)
        {
            Console.SetCursorPosition(platformX, platformY);
            Console.ForegroundColor = platformColor;
            Console.Write(platformSymbol);
        }


    }
}
