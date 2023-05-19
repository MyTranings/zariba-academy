// 8. Draw on the console a 3 by 6 rectangle with the symbol ?.

using System;

namespace _08.DrawRectangle
{
    class DrawRectangle
    {
        static void Main()
        {
            char symbol = '?';

            Console.WriteLine(new string(symbol, 3));
            Console.WriteLine(new string(symbol, 3));
            Console.WriteLine(new string(symbol, 3));
            Console.WriteLine(new string(symbol, 3));
            Console.WriteLine(new string(symbol, 3));
            Console.WriteLine(new string(symbol, 3));
        }
    }
}
