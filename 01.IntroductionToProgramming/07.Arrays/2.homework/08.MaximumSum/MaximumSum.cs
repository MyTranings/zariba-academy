using System;
using System.Linq;

class MaximumSum
{
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int maxSum = int.MinValue;
        int buffer = 0;
        int bufStartIndex = 0;
        int maxSumStartIndex = 0;
        int maxSumEndIndex = 0;
        int counter = 0;

        //Console.WriteLine(arr.Sum());

        for (int i = 0; i < arr.Length; i++)
        {
            buffer += arr[i];

            if (buffer > maxSum)
            {
                maxSum = buffer;
                maxSumEndIndex = i;
                if (i + 1 < arr.Length && buffer + arr[i + 1] < maxSum)
                {
                    bufStartIndex = i - counter;
                    maxSumStartIndex = i - counter;
                    counter = 0;
                    buffer = 0;
                }
                else
                {
                    counter++;
                }
            }
            else if (buffer == 0)
            {
                counter = 0;
                buffer = 0;
            }
            else
            {
                counter++;
            }
        }
        for (int j = maxSumStartIndex; j <= maxSumEndIndex; j++)
        {
            Console.WriteLine(arr[j]);
        }
    }
}