//04. Create a character variable and assign it with the character with Unicode 90. Hint: Same as 3.
using System;
using System.Text;

class CharType
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        char symbol = '\u0090';

        Console.WriteLine(symbol);
    }
}
