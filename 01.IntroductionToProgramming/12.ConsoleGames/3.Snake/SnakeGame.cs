using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGameDemo
{
    struct Position
    {
        public int Row;
        public int Col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    //Update() -> Game Logic
    //Create() -> Create/instantiate them
    //Preload() -> List objects that you will use
    class SnakeGame
    {
        static Random rng;

        static Queue<Position> snakeElements = new Queue<Position>();
        static Position snakeHead;
        static Position snakeNewHead;

        static Position[] directions = new Position[4];
        static byte directionIndex;
        static byte right;
        static byte left;
        static byte down;
        static byte up;

        static int lastFoodTime;
        static int foodDisappearTime;
        static Position food;
        static Position goodFood;

        static List<Position> obstacles = new List<Position>();
        static Position obstacle;

        static int userPoints;
        static int negativePoints;
        static double sleepTime;
        static bool isGameOver;

        static void Main()
        {
            
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 50;

            InitializeSnakeElements();

            while (!isGameOver)
            {
                negativePoints++;

                InputHandler();
                MoveSnake();
                EatFoodLogic();
                GenerateFoodIfNotPickedUp();
                GameOverLogic();
                RedrawOldHead();
                DrawNewHead();

                snakeElements.Enqueue(snakeNewHead);

                sleepTime -= 0.1;
                Thread.Sleep(Math.Max((int)sleepTime,20));
                
            }

        }

        private static void GameOverLogic()
        {
            if (snakeElements.Contains(snakeNewHead) || 
                obstacles.Contains(snakeNewHead))
            {
                isGameOver = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Game Over!");
                userPoints = (snakeElements.Count - 5) * 100 - negativePoints;
                userPoints = Math.Max(userPoints, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your points {0}",userPoints);
                Console.ReadLine();
            }
        }

        private static void GenerateFoodIfNotPickedUp()
        {
            //current time between last food generated and now is bigger than 5secs
            if (Environment.TickCount-lastFoodTime>=foodDisappearTime)
            {
                Console.SetCursorPosition(food.Col, food.Row);
                Console.Write(" ");
                negativePoints += 50;
                GenerateFood();
                DrawFood();
            }
        }

        private static void EatFoodLogic()
        {
            if (food.Row == snakeNewHead.Row && food.Col == snakeNewHead.Col)
            {
                lastFoodTime = Environment.TickCount;
                sleepTime -= 5;
                GenerateFood();
                DrawFood();
                GenerateANewObstacle();
                DrawNewObstacle();
            }
            else
            {
                Position snakeTail = snakeElements.Dequeue();
                Console.SetCursorPosition(snakeTail.Col, snakeTail.Row);
                Console.Write(" ");
            }
        }

        private static void DrawNewObstacle()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(obstacle.Col,obstacle.Row);
            Console.Write("$");
        }

        private static void DrawNewHead()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            if (directionIndex==right)
            {
                Console.Write(">");
            }
            else if (directionIndex==left)
            {
                Console.Write("<");
            }
            else if (directionIndex == down)
            {
                Console.Write("v");
            }
            else if (directionIndex == up)
            {
                Console.Write("^");
            }
        }

        private static void RedrawOldHead()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(snakeHead.Col, snakeHead.Row);
            Console.Write("*");
        }

        private static void MoveSnake()
        {
            snakeHead = snakeElements.Last();
            Position nextDirection = directions[directionIndex];
            snakeNewHead = new Position(snakeHead.Row + nextDirection.Row
                , snakeHead.Col + nextDirection.Col);
            TeleportSnake();
        }

        private static void TeleportSnake()
        {
            if (snakeNewHead.Col<0)
            {
                snakeNewHead.Col = Console.WindowWidth - 1;
            }
            else if (snakeNewHead.Row<0)
            {
                snakeNewHead.Row = Console.WindowHeight - 1;
            }
            else if (snakeNewHead.Row >= Console.WindowHeight)
            {
                snakeNewHead.Row = 0;
            }
            else if (snakeNewHead.Col >= Console.WindowWidth)
            {
                snakeNewHead.Col = 0;
            }
        }

        private static void InputHandler()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.RightArrow && directionIndex!=left)
                {
                    directionIndex = right;
                }
                else if (userInput.Key == ConsoleKey.LeftArrow && directionIndex != right)
                {
                    directionIndex = left;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && directionIndex != up)
                {
                    directionIndex = down;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && directionIndex != down)
                {
                    directionIndex = up;
                }
            }
        }

        static void InitializeSnakeElements()
        {
            rng = new Random();

            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
            DrawSnakeBody();

            directions = new Position[]
                {
                    new Position(0,1), //right
                    new Position(0,-1), //left
                    new Position(1,0), // down
                    new Position(-1,0), //up
                };
            directionIndex = right;
            right = 0;
            left = 1;
            down = 2;
            up = 3;

            GenerateFood();
            //This counts the time in miliseconds
            lastFoodTime = Environment.TickCount;
            foodDisappearTime = 5000;
            DrawFood();

            for (int i = 0; i < 7; i++)
            {
                GenerateANewObstacle();
            }
            DrawObstacles();

            userPoints = 0;
            negativePoints = 0;
            sleepTime = 100;
            isGameOver = false;
        }

        static void DrawFood()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(food.Col, food.Row);
            Console.Write("@");
        }

        static void DrawObstacles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var obst in obstacles)
            {
                Console.SetCursorPosition(obst.Col, obst.Row);
                Console.Write("$");
            }
        }

        static void GenerateANewObstacle()
        {
            do
            {
                obstacle = new Position(rng.Next(0, Console.WindowHeight),
                rng.Next(0, Console.WindowWidth));
            } while (snakeElements.Contains(obstacle) || obstacles.Contains(obstacle)
            || (food.Row==obstacle.Row && food.Col == obstacle.Col));
            obstacles.Add(obstacle);
            
        }

        static void GenerateFood()
        {
            do
            {
                food = new Position(rng.Next(0, Console.WindowHeight),
                rng.Next(0, Console.WindowWidth));
            } while (snakeElements.Contains(food) || obstacles.Contains(food));
            //restart apple timer
            lastFoodTime = Environment.TickCount;

        }

        static void DrawSnakeBody()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (Position element in snakeElements)
            {
                Console.SetCursorPosition(element.Col, element.Row);
                Console.Write("*");
            }
        }
    }
}
