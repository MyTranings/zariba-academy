//5. Write a program that finds the maximal increasing sequence in an array.
//  Example: { 3, 2, 3, 4, 2, 2, 4} ? {2, 3, 4}.

using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        Console.Write("Enter a sequnce of numbers separated by space: ");
        string[] sequence = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] sequenceNumb = new int[sequence.Length];

        for (int i = 0; i < sequence.Length; i++)
        {
            sequenceNumb[i] = int.Parse(sequence[i]);
        }

        int minValue = 0;
        int counter = 0;
        int resultSequenceStart = 0;
        int resultSequenceEnd = 0;
        int longestSequence = 0;

        for (int i = 0; i < sequenceNumb.Length; i++)
        {
            counter = 0;
            minValue = sequenceNumb[i];            
            for (int j = i + 1; j < sequenceNumb.Length; j++)
            {
                if (minValue < sequenceNumb[j])
                {
                    counter++;
                    minValue = sequenceNumb[j];
                    if (counter > longestSequence)
                    {
                        longestSequence = counter;
                        resultSequenceStart = i;
                        resultSequenceEnd = j;
                    }
                    else if (counter == longestSequence)
                    {
                        int firstSum = 0;
                        int secondSum = 0;

                        for (int k = resultSequenceStart; k <= resultSequenceEnd; k++)
                        {
                            firstSum += sequenceNumb[k];
                        }

                        for (int m = i; m <= j; m++)
                        {
                            secondSum += sequenceNumb[m];
                        }

                        if (secondSum > firstSum)
                        {
                            resultSequenceStart = i;
                            resultSequenceEnd = j;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
        
        Console.WriteLine(resultSequenceStart);
        Console.WriteLine(resultSequenceEnd);
        Console.Write("The maximal increasing sequence of numbers is: {");
        for (int i = resultSequenceStart; i <= resultSequenceEnd; i++)
        {
            Console.Write(" {0},", sequenceNumb[i]);
        }
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        Console.WriteLine(" }");
    }
}