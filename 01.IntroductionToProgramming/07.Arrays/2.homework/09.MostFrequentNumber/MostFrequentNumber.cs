//9. Write a program that finds the most frequent number in an array.
    //Example: { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;

class MostFrequentNumber
{
    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int count = 0;
        int maxTimes = int.MinValue;
        int mostFrequent = arr[0];
        int buf;

        for (int i = 0; i < arr.Length; i++)
        {
            count = 0;
            buf = arr[i];
            for (int j = 0; j < arr.Length; j++)
            {
                if (buf == arr[j])
                {
                    count++;
                    if (count > maxTimes)
                    {
                        maxTimes = count;
                        mostFrequent = buf;
                    }
                }
            }
        }
        Console.WriteLine("Most frequent numner is {0} -> {1} times", mostFrequent, maxTimes);
    }
}
