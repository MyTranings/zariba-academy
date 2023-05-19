using System;
using System.Text;

class CoolSb
{
    static void Main()
    {
        DateTime start = DateTime.Now;
        string testString = DuplicateChars('a', 10000);
        DateTime end = DateTime.Now;
        Console.WriteLine(end - start);
        DateTime start1 = DateTime.Now;
        string testString1 = DuplicateChars('a', 200000000);
        DateTime end1 = DateTime.Now;
        Console.WriteLine(end1 - start1);
    }
    static string DuplicateChars(char symbol, int numberOfChars)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < numberOfChars; i++)
        {
            result.Append(symbol);
        }
        return result.ToString();
    }
}



