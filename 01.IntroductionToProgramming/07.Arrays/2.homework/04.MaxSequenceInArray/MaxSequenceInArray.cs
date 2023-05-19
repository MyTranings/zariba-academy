//4. Write a program that finds the maximal sequence of equal elements in an array.
// Example: { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1} ? {2, 2, 2}.

using System;

class MaxSequenceInArray
{
    static void Main()
    {
        Console.Write("Enter a sequence of numbers separeted by space: ");
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string buff = "";
        string result = "";
        int counter = 0,
            maxSequence = 0;

        for (int i = 0; i < input.Length; i++)
        {
            buff = input[i];
            counter++;
            for (int j = i + 1; j < input.Length; j++)
            {
                if (buff == input[j])
                {
                    counter++;
                }
                else
                {
                    if (maxSequence < counter)
                    {
                        maxSequence = counter;
                        result = buff;
                    }
                    counter = 0;
                    break;
                }
            }
        }

        Console.Write("Longest sequence of equal elements is: {");
        for (int j = 1; j <= maxSequence; j++)
        {
            Console.Write(" {0},", result);
        }
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        Console.WriteLine(" }");
    }
}