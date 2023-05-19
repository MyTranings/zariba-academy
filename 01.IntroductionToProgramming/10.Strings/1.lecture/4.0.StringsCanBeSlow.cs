using System;

class PlusSignForStringsIsBad
{
    static void Main(string[] args)
    {
        DateTime start = DateTime.Now;
        string testString = DuplicateChars('a',10000);
        DateTime end = DateTime.Now;
        Console.WriteLine(end-start);
        DateTime start1 = DateTime.Now;
        string testString1 = DuplicateChars('a', 100000);
        DateTime end1 = DateTime.Now;
        Console.WriteLine(end1 - start1);
    }
    static string DuplicateChars(char symbol, int numberOfChars)
    {
        string result = "";
        for (int i = 0; i < numberOfChars; i++)
        {
            result = result + symbol;
        }
        return result;
    }
}

