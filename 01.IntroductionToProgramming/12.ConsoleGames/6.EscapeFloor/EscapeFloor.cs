namespace EscapeFloorExamSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

    class EscapeFloor
    {


        public const int PLAYFIELD_HEIGHT = 30;
        public const int PLAYFIELD_WIDTH = 40;
        public const int SCORE_WIDTH_ADD = 15;
        public static int[,] playfield = new int[PLAYFIELD_HEIGHT, PLAYFIELD_WIDTH];
        //Floor stuff
        public static int holeWidth = 10;

        //PlayerStuff
        public static List<Position> playerPositions;
        public static bool shouldPlayerMoveDown = true;

        //PowerUps
        public static List<Position> powerUps = new List<Position>();
        public static int startTime;
        public static bool faster = false;
        public static bool slower = false;
   

        public static Random rng = new Random();
        public static bool isGameOver = false;
        public static int difficulty = 150;
        public static string difficultyString = "Easy";
        public static ConsoleColor difficultyColor = ConsoleColor.Green;
        public static int points = 0;
        public static int skipFloorsCounter = 2;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = PLAYFIELD_HEIGHT;
            Console.BufferWidth = Console.WindowWidth = PLAYFIELD_WIDTH + SCORE_WIDTH_ADD;
            Console.CursorVisible = false;
            // Draw the Player
            // Move the Player - horizontal and vertical
            // Initialize the player

            //Draw UI
            //Difficulties
            //Points

            //PowerUps
            //GameOver
            InitializePlayer();

            int stepsCounter = 1;
            startTime = Environment.TickCount;

            while (!isGameOver)
            {
                if (stepsCounter % 12 == 0)
                {
                    GenerateFloors();
                    GeneratePU();
                }
                DrawPU();
                DrawFloors();
                ClearFirstRow();
                DrawPlayer();
                CheckFloorCollision();
                CheckPowerUpCollision();
                MoveFloorsUp();
                MovePuUp();
                MovePlayerHorizontally();
                MovePlayerVertically();
                SetPoints();

                SetDifficulty();
                ResetDifficulty();
                GameOverConditions();
                //ToDo -> going through a floor generates 20 points
                DrawUI();
                Thread.Sleep(difficulty);
                Console.Clear();
                stepsCounter++;
                points++;
            }
            Console.WriteLine("GG!");
            Console.WriteLine("Your points were: {0}", points);
            Console.WriteLine("You suck!");
        }

        private static void SetPoints()
        {
            var row = playerPositions[1].X;
            for (int i = 0; i < PLAYFIELD_WIDTH; i++)
            {
                if (playfield[row,i]==1)
                {
                    points += 20;
                    break;
                }
            }
        }

        private static void ResetDifficulty()
        {
            if (Environment.TickCount - startTime>5000 && faster)
            {
                startTime = Environment.TickCount;
                faster = false;
                difficulty += 15;
            }
            else if (Environment.TickCount-startTime > 7000 && slower)
            {
                startTime = Environment.TickCount;
                slower = false;
                difficulty -= 15;
            }
        }

        private static void CheckPowerUpCollision()
        {
            foreach (var bodyPart in playerPositions)
            {
                for (int i = 0; i < powerUps.Count; i++)
                {
                    if (bodyPart.X == powerUps[i].X && bodyPart.Y == powerUps[i].Y)
                    {
                        if (powerUps[i].Symbol == '@' && faster == false)
                        {
                            startTime = Environment.TickCount;
                            faster = true;
                            slower = false;
                            difficulty -= 15;

                        }
                        else if (powerUps[i].Symbol == '&' && slower == false)
                        {
                            startTime = Environment.TickCount;
                            slower = true;
                            faster = false;
                            difficulty += 15;
                        }
                        else if (powerUps[i].Symbol == '$')
                        {
                            skipFloorsCounter=0;
                        }
                        powerUps[i] = new Position(0, 0, ' ');
                    }
                }
            }
        }

        private static void DrawPU()
        {
            if (powerUps.Count != 0)
            {
                foreach (var pu in powerUps)
                {
                    Console.SetCursorPosition(pu.Y, pu.X);
                    if (pu.Symbol == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (pu.Symbol == '&')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (pu.Symbol == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(pu.Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private static void MovePuUp()
        {
            for (int i = 0; i < powerUps.Count; i++)
            {
                if (powerUps[i].X > 0)
                {
                    powerUps[i] = new Position(powerUps[i].X - 1, powerUps[i].Y, powerUps[i].Symbol);
                }
                else if (powerUps[i].X == 0)
                {
                    powerUps[i] = new Position(0, 0, ' ');
                }
            }
        }
        private static void GeneratePU()
        {
            int generationPercentage = rng.Next(0, 101);
            if (generationPercentage < 50 && generationPercentage >= 30)
            {
                powerUps.Add(new Position(PLAYFIELD_HEIGHT - 2, rng.Next(1, PLAYFIELD_WIDTH), '@'));
            }
            if (generationPercentage < 30 && generationPercentage >= 15)
            {
                powerUps.Add(new Position(PLAYFIELD_HEIGHT - 2, rng.Next(1, PLAYFIELD_WIDTH), '&'));
            }
            if (generationPercentage < 15 && generationPercentage >= 5)
            {
                powerUps.Add(new Position(PLAYFIELD_HEIGHT - 2, rng.Next(1, PLAYFIELD_WIDTH), '$'));
            }
        }

        private static void GameOverConditions()
        {
            if (playerPositions[0].X == 0)
            {
                isGameOver = true;
            }
        }

        private static void SetDifficulty()
        {
            if (points > 80 && points < 160)
            {
                difficulty = 100;
                difficultyColor = ConsoleColor.Yellow;
                difficultyString = "Medium";
                holeWidth = 8;
            }
            if (points > 160)
            {
                difficulty = 70;
                difficultyColor = ConsoleColor.Red;
                difficultyString = "Hard";
                holeWidth = 5;
            }
        }

        private static void CheckFloorCollision()
        {
            Position rightLeg = playerPositions.Last();
            int legX = rightLeg.X;
            int legY = rightLeg.Y;

            if (playfield[legX + 1, legY] == 1 || playfield[legX + 1, legY - 2] == 1)
            {
                shouldPlayerMoveDown = false;
            }
            else
            {
                shouldPlayerMoveDown = true;
            }
        }

        private static void MovePlayerVertically()
        {
            if (shouldPlayerMoveDown)
            {
                if (playerPositions[0].X + 4 < PLAYFIELD_HEIGHT)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X + 1, playerPositions[i].Y, playerPositions[i].Symbol);
                    }
                }
            }
            else
            {
                if (playerPositions[0].X >= 0)
                {
                    for (int i = 0; i < playerPositions.Count; i++)
                    {
                        playerPositions[i] = new Position(playerPositions[i].X - 1, playerPositions[i].Y, playerPositions[i].Symbol);
                    }
                }
            }
        }

        private static void MovePlayerHorizontally()
        {
            if (Console.KeyAvailable)
            {
                //hack
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (playerPositions[0].Y - 3 >= 0)
                    {
                        for (int i = 0; i < playerPositions.Count; i++)
                        {
                            playerPositions[i] = new Position(playerPositions[i].X, playerPositions[i].Y - 3, playerPositions[i].Symbol);
                        }
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (playerPositions[0].Y + 3 <= PLAYFIELD_WIDTH)
                    {
                        for (int i = 0; i < playerPositions.Count; i++)
                        {
                            playerPositions[i] = new Position(playerPositions[i].X, playerPositions[i].Y + 3, playerPositions[i].Symbol);
                        }
                    }
                }
            }
        }

        private static void DrawPlayer()
        {
            foreach (Position bodyPart in playerPositions)
            {
                Console.SetCursorPosition(bodyPart.Y, bodyPart.X);
                Console.Write(bodyPart.Symbol);
            }
        }

        private static void InitializePlayer()
        {
            playerPositions = new List<Position>();
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2, PLAYFIELD_WIDTH / 2, 'O'));
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2 + 1, PLAYFIELD_WIDTH / 2, '|'));
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2, PLAYFIELD_WIDTH / 2 - 1, '_'));
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2, PLAYFIELD_WIDTH / 2 + 1, '_'));
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2 + 2, PLAYFIELD_WIDTH / 2 - 1, '/'));
            playerPositions.Add(new Position(PLAYFIELD_HEIGHT / 2 + 2, PLAYFIELD_WIDTH / 2 + 1, '\\'));

        }

        private static void DrawUI()
        {
            for (int i = 0; i < PLAYFIELD_HEIGHT; i++)
            {
                Console.SetCursorPosition(PLAYFIELD_WIDTH, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(PLAYFIELD_WIDTH + 1, 3);
            Console.Write("Points: {0}", points);
            Console.SetCursorPosition(PLAYFIELD_WIDTH + 1, 5);
            Console.Write("Diff: ");
            Console.ForegroundColor = difficultyColor;
            Console.Write(difficultyString);
            Console.Write(new string(' ',48)+difficulty);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ClearFirstRow()
        {
            for (int i = 0; i < PLAYFIELD_WIDTH; i++)
            {
                playfield[0, i] = 0;
            }
        }

        private static void DrawFloors()
        {
            for (int i = 0; i < PLAYFIELD_HEIGHT; i++)
            {
                for (int j = 0; j < PLAYFIELD_WIDTH; j++)
                {
                    if (playfield[i, j] == 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("*");
                    }
                }
            }
        }

        private static void MoveFloorsUp()
        {
            for (int i = 0; i < PLAYFIELD_HEIGHT; i++)
            {
                for (int j = 0; j < PLAYFIELD_WIDTH; j++)
                {
                    if (playfield[i, j] == 1)
                    {
                        playfield[i, j] = 0;
                        playfield[i - 1, j] = 1;
                    }
                }
            }
        }

        private static void GenerateFloors()
        {
            if (skipFloorsCounter>=2)
            {
                int startingPosition = rng.Next(0, PLAYFIELD_WIDTH - holeWidth);
                int startingRow = PLAYFIELD_HEIGHT - 1;
                for (int i = 0; i < PLAYFIELD_WIDTH; i++)
                {
                    playfield[startingRow, i] = 1;
                }

                for (int i = startingPosition; i <= startingPosition + holeWidth; i++)
                {
                    playfield[startingRow, i] = 0;
                }
            }
            skipFloorsCounter++;
        }
    }
}
