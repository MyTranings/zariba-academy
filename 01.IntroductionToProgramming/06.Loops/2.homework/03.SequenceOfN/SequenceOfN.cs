// 3. Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class SequenceOfN
{
    static void Main()
    {
        Console.Write("Enter a sequence of numbers separeted by space: ");
        string[] sequence = Console.ReadLine().Split(' ');
        int[] numbers = new int[sequence.Length];
        Nullable<int> min = new Nullable<int>();
        Nullable<int> max = new Nullable<int>();

        for (int i = 0; i < sequence.Length; i++)
        {
            numbers[i] = int.Parse(sequence[i]);

            if (!min.HasValue)
            {
                min = numbers[i];
            }
            else
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }

            if (!max.HasValue)
            {
                max = numbers[i];
            }
            else
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
        }
        
        Console.WriteLine("Min number: {0}\nMax Number: {1}", min, max);
    }
}