using System;
using System.Collections.Generic;
using System.Threading;

struct Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    public ConsoleColor Colour { get; set; }

    public Position(int x, int y, char symbol, ConsoleColor colour)
    {
        this.X = x;
        this.Y = y;
        this.Symbol = symbol;
        this.Colour = colour;
    }
}

class Pooyan
{
    // Level parameters
    public const int PLAYFIELD_BUFFER = 20;
    public const int PLAYFIELD_WIDTH = 60;
    public const int PLAYFIELD_HEIGHT = 30;
    public const int PLAYFIELD_MAX_WIDTH = PLAYFIELD_WIDTH - 1;

    public static int[,] playfield = new int[PLAYFIELD_HEIGHT, PLAYFIELD_WIDTH];

    public const int PLAYFIED_HEIGHT_SPACE = 1;
    public const int PLAYFIED_WIDTH_SPACE = 2;
    public const int TOP_PLAFORM_WIDTH = 30;
    public const int TREE_HEIGHT = 29;
    public const int TREE_ROOT_HEIGHT = 6;
    public const int RIGHT_SIDE_SHELTER = 6;

    // Player parameters
    public const int PLAYER_WIDTH = 7;
    public const int PLAYER_HEIGHT = 5;
    public const int PLAYER_LEFT_POSITION = PLAYFIELD_MAX_WIDTH - PLAYFIED_WIDTH_SPACE - RIGHT_SIDE_SHELTER - RIGHT_SIDE_SHELTER / 2 + 1;
    public const int ROPE_COL = PLAYER_LEFT_POSITION + PLAYER_WIDTH / 2;
    public const ConsoleColor PLAYER_BORDER_COLOUR = ConsoleColor.White;
    public const ConsoleColor PLAYER_COLOUR = ConsoleColor.Yellow;
    public const ConsoleColor PLAYER_ARROW_COLOUR = ConsoleColor.Red;

    public const int ARROW_WIDTH = 5;

    public static List<Position> playerPositions;
    public static List<List<Position>> arrows = new List<List<Position>>();
    public static int player_top_position = PLAYFIED_HEIGHT_SPACE + 1;
    public static int[] arrowPosition = { player_top_position + PLAYER_HEIGHT / 2, PLAYER_LEFT_POSITION };

    public static List<List<Position>> enemies = new List<List<Position>>();


    static void Main()
    {
        Console.BufferWidth = Console.WindowWidth = PLAYFIELD_WIDTH + PLAYFIELD_BUFFER;
        Console.BufferHeight = Console.WindowHeight = PLAYFIELD_HEIGHT;
        Console.CursorVisible = false;

        // Draw level
        DrawLevel();

        // Initialize player
        InitilizePlayer();
        DrawPlayer();

        // Draw enemies

        bool isGameOver = false;
        while (!isGameOver)
        {
            if (arrows.Count > 0)
            {
                MoveArrow();
            }

            KeyHandler();
            InitilizeEnemy();
            DrawEnemy();

            Thread.Sleep(150);
        }
    }

    private static void DrawEnemy()
    {
        foreach (var enemy in enemies)
        {
            foreach (var enemyParts in enemy)
            {
                if (playfield[enemyParts.X, enemyParts.Y] == 0)
                {
                    Console.SetCursorPosition(enemyParts.Y, enemyParts.X);
                    Console.Write(enemyParts.Symbol);
                    playfield[enemyParts.X, enemyParts.Y] = 4;
                }
            }
        }
    }

    private static void InitilizeEnemy()
    {
        List<Position> enemy = new List<Position>();

        Random rng = new Random();

        int leftPosition = rng.Next(PLAYFIED_WIDTH_SPACE, TOP_PLAFORM_WIDTH);

        enemy.Add(new Position(PLAYFIED_HEIGHT_SPACE, leftPosition, '<', ConsoleColor.White));
        enemy.Add(new Position(PLAYFIED_HEIGHT_SPACE, leftPosition, 'D', ConsoleColor.White));
        enemy.Add(new Position(PLAYFIED_HEIGHT_SPACE, leftPosition, '>', ConsoleColor.White));

        enemies.Add(enemy);
    }

    private static void MoveArrow()
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            for (int j = 0; j < arrows[i].Count; j++)
            {
                if (playfield[arrows[i][j].X, arrows[i][j].Y - 1] == 0)
                {

                    ClearArrow(arrows[i]);

                    arrows[i][j] = new Position(arrows[i][j].X, arrows[i][j].Y - 1, arrows[i][j].Symbol, arrows[i][j].Colour);

                    DrawArrow();
                }
                else
                {
                    ClearArrow(arrows[i]);
                }
            }
        }
    }

    private static void ClearArrow(List<Position> arrow)
    {
        foreach (var arrowParts in arrow)
        {
            Console.SetCursorPosition(arrowParts.Y, arrowParts.X);
            Console.Write(' ');
            playfield[arrowParts.X, arrowParts.Y] = 0;
        }
    }



    private static void DrawArrow()
    {
        ChangeColor(PLAYER_ARROW_COLOUR);
        foreach (var arrow in arrows)
        {
            foreach (var arrowParts in arrow)
            {
                int nextBox = playfield[arrowParts.X, arrowParts.Y - 1];
                if (nextBox == 0 || nextBox == 3)
                {
                    Console.SetCursorPosition(arrowParts.Y, arrowParts.X);
                    Console.Write(arrowParts.Symbol);
                    playfield[arrowParts.X, arrowParts.Y] = 3;
                }
            }
        }
        ResetColor();
    }

    private static void DrawArrows1(int x, int y, char symbol)
    {
        ChangeColor(PLAYER_ARROW_COLOUR);

        Console.SetCursorPosition(y, x);
        Console.Write(symbol);
        playfield[x, y] = 3;
    }

    private static void KeyHandler()
    {
        if (Console.KeyAvailable)
        {
            bool canMove = true;

            // Hack
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            while (Console.KeyAvailable) Console.ReadKey(true);

            if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                int lastIndex = playerPositions.Count - 1;
                int[] playerCurBottom = { playerPositions[lastIndex].X, playerPositions[lastIndex].Y - (PLAYER_WIDTH / 2) };
                int ropeRow = playerPositions[0].X;
                arrowPosition[0]++;
                for (int i = 0; i < PLAYER_WIDTH; i++)
                {
                    int nextBox = playfield[playerCurBottom[0] + 1, playerCurBottom[1] + i];
                    if (nextBox == 1 || nextBox == 4)
                    {
                        canMove = false;
                        break;
                    }
                }
                if (canMove)
                {
                    ClearPlayer();
                    for (int j = 0; j < playerPositions.Count; j++)
                    {
                        playerPositions[j] = new Position(playerPositions[j].X + 1, playerPositions[j].Y, playerPositions[j].Symbol, playerPositions[j].Colour);
                    }
                    DrawPlayer();
                    DrawRope(ropeRow);
                }
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                int[] playerCurTop = { playerPositions[0].X, playerPositions[0].Y - (PLAYER_WIDTH / 2) };
                int ropeRow = playerPositions[0].X;
                arrowPosition[0]--;
                for (int i = 0; i < PLAYER_WIDTH; i++)
                {
                    int nextBox = playfield[playerCurTop[0] - 1, playerCurTop[1] + i];
                    if (nextBox == 1 && nextBox == 4)
                    {
                        canMove = false;
                        break;
                    }
                }

                if (canMove)
                {
                    ClearPlayer();
                    for (int j = 0; j < playerPositions.Count; j++)
                    {
                        playerPositions[j] = new Position(playerPositions[j].X - 1, playerPositions[j].Y, playerPositions[j].Symbol, playerPositions[j].Colour);
                    }
                    DeleteRope(ropeRow);
                    DrawPlayer();
                }
            }
            else if (pressedKey.Key == ConsoleKey.Spacebar)
            {
                if (playfield[arrowPosition[0], arrowPosition[1] - 1] == 0)
                {
                    InitilizeArrow();
                    DrawArrow();
                }
            }
        }
    }

    private static void InitilizeArrow()
    {
        List<Position> arrow = new List<Position>();

        arrow.Add(new Position(arrowPosition[0], arrowPosition[1], '<', PLAYER_ARROW_COLOUR));
        arrow.Add(new Position(arrowPosition[0], arrowPosition[1] + 1, '-', PLAYER_ARROW_COLOUR));
        arrow.Add(new Position(arrowPosition[0], arrowPosition[1] + 2, '-', PLAYER_ARROW_COLOUR));
        arrow.Add(new Position(arrowPosition[0], arrowPosition[1] + 3, '-', PLAYER_ARROW_COLOUR));
        arrow.Add(new Position(arrowPosition[0], arrowPosition[1] + 4, 'c', PLAYER_ARROW_COLOUR));

        arrows.Add(arrow);
    }

    private static void DeleteRope(int ropeRow)
    {
        Console.SetCursorPosition(ROPE_COL, ropeRow);
        Console.Write(' ');
    }

    private static void DrawRope(int ropeRow)
    {
        Console.SetCursorPosition(ROPE_COL, ropeRow);
        Console.Write('|');
        playfield[ropeRow, ROPE_COL] = 2;
    }

    private static void ClearPlayer()
    {
        foreach (var bodyParts in playerPositions)
        {
            Console.SetCursorPosition(bodyParts.Y, bodyParts.X);
            Console.Write(' ');
            playfield[bodyParts.X, bodyParts.Y] = 0;
        }
    }

    private static void DrawPlayer()
    {
        foreach (var bodyParts in playerPositions)
        {
            Console.ForegroundColor = bodyParts.Colour;
            Console.SetCursorPosition(bodyParts.Y, bodyParts.X);
            playfield[bodyParts.X, bodyParts.Y] = 2;
            Console.Write(bodyParts.Symbol);
        }
        ResetColor();
    }

    private static void InitilizePlayer()
    {

        playerPositions = new List<Position>();
        // Row 1 Center
        playerPositions.Add(new Position(player_top_position, PLAYER_LEFT_POSITION + 3, '-', PLAYER_BORDER_COLOUR));
        // Row 1
        playerPositions.Add(new Position(player_top_position, PLAYER_LEFT_POSITION + 2, '-', PLAYER_BORDER_COLOUR));
        playerPositions.Add(new Position(player_top_position, PLAYER_LEFT_POSITION + 4, '-', PLAYER_BORDER_COLOUR));
        // Row 2
        playerPositions.Add(new Position(player_top_position + 1, PLAYER_LEFT_POSITION + 1, '/', PLAYER_BORDER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 1, PLAYER_LEFT_POSITION + 3, '0', PLAYER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 1, PLAYER_LEFT_POSITION + 5, '\\', PLAYER_BORDER_COLOUR));
        // Row 3
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION, '<', PLAYER_ARROW_COLOUR));
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION + 1, '-', PLAYER_ARROW_COLOUR));
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION + 2, '=', PLAYER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION + 3, '|', PLAYER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION + 4, '=', PLAYER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 2, PLAYER_LEFT_POSITION + 6, '|', PLAYER_BORDER_COLOUR));
        // Row 4
        playerPositions.Add(new Position(player_top_position + 3, PLAYER_LEFT_POSITION + 1, '\\', PLAYER_BORDER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 3, PLAYER_LEFT_POSITION + 3, 'W', PLAYER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 3, PLAYER_LEFT_POSITION + 5, '/', PLAYER_BORDER_COLOUR));
        // Row 5
        playerPositions.Add(new Position(player_top_position + 4, PLAYER_LEFT_POSITION + 2, '-', PLAYER_BORDER_COLOUR));
        playerPositions.Add(new Position(player_top_position + 4, PLAYER_LEFT_POSITION + 4, '-', PLAYER_BORDER_COLOUR));
        // Row 5 center
        playerPositions.Add(new Position(player_top_position + 4, PLAYER_LEFT_POSITION + 3, '-', PLAYER_BORDER_COLOUR));


    }

    private static void DrawLevel()
    {
        DrawTopPlatform();
        DrawLeftTree();
        DrawRightTree();
        DrawGround();
        DrawPlayerHolder();
    }

    private static void DrawPlayerHolder()
    {
        int rightSideTopCol = PLAYFIELD_MAX_WIDTH - PLAYFIED_WIDTH_SPACE - RIGHT_SIDE_SHELTER + 1;
        int endCol = rightSideTopCol + RIGHT_SIDE_SHELTER;

        ResetColor();
        for (int col = rightSideTopCol; col < endCol; col++)
        {
            Console.SetCursorPosition(col, PLAYFIED_HEIGHT_SPACE);
            Console.Write('o');
            playfield[PLAYFIED_HEIGHT_SPACE, col] = 1;
        }
    }

    private static void DrawRightTree()
    {
        int maxCol = PLAYFIELD_MAX_WIDTH - 1;

        ChangeColor(ConsoleColor.Red);
        for (int row = PLAYFIED_HEIGHT_SPACE; row < TREE_HEIGHT; row++)
        {
            Console.SetCursorPosition(maxCol, row);
            Console.Write('_');
            playfield[row, maxCol] = 1;

            if (row == 1)
            {
                Console.SetCursorPosition(PLAYFIELD_MAX_WIDTH, row);
                playfield[row, PLAYFIELD_MAX_WIDTH] = 1;
                Console.Write('-');
                Console.SetCursorPosition(PLAYFIELD_MAX_WIDTH - 1, row);
                playfield[row, PLAYFIELD_MAX_WIDTH - 1] = 1;
                Console.Write('-');
            }
            else
            {
                Console.SetCursorPosition(maxCol - 1, row);
                playfield[row, maxCol - 1] = 1;
                Console.Write('|');
            }
        }
        ResetColor();
    }

    private static void DrawGround()
    {
        int groundPostion = PLAYFIELD_HEIGHT - PLAYFIED_HEIGHT_SPACE - 1;

        ChangeColor(ConsoleColor.Green);
        for (int col = 0; col < PLAYFIELD_MAX_WIDTH; col++)
        {
            if (playfield[groundPostion, col] == 0)
            {
                Console.SetCursorPosition(col, groundPostion);
                Console.Write('_');
                playfield[groundPostion, col] = 1;
            }
        }
        ResetColor();
    }

    private static void DrawLeftTree()
    {
        int treeTopPosition = PLAYFIED_HEIGHT_SPACE + 1;
        int counter = 0;

        ChangeColor(ConsoleColor.Green);
        for (int row = PLAYFIED_WIDTH_SPACE; row < TREE_HEIGHT; row++)
        {
            if (row >= (TREE_HEIGHT - TREE_ROOT_HEIGHT))
            {
                counter++;
                Console.SetCursorPosition(treeTopPosition + counter, row);
                Console.Write('\\');
                playfield[row, treeTopPosition + counter] = 1;
            }
            else
            {
                Console.SetCursorPosition(treeTopPosition, row);
                Console.Write('|');
                playfield[row, treeTopPosition] = 1;
            }
        }
        ResetColor();
    }

    private static void DrawTopPlatform()
    {

        ChangeColor(ConsoleColor.DarkYellow);
        for (int col = PLAYFIED_WIDTH_SPACE; col < TOP_PLAFORM_WIDTH; col++)
        {
            Console.SetCursorPosition(col, PLAYFIED_HEIGHT_SPACE);
            Console.Write('_');
            playfield[PLAYFIED_HEIGHT_SPACE, col] = 1;
        }
        ResetColor();
    }

    private static void ChangeColor(ConsoleColor clr)
    {
        Console.ForegroundColor = clr;
    }

    private static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}
