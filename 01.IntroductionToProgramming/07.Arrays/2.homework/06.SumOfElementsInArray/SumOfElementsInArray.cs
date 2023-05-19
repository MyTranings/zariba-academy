//6. Write a program that reads two integer numbers N and K and an array of N elements from the console.
//    Find in the array those K elements that have maximal sum.

using System;

class SumOfElementsInArray
{
    static void Main()
    {
        Console.Write("How many elements you will enter: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int m = 0; m < n; m++)
        {
            Console.Write("Enter {0} number from the array: ", m + 1);
            arr[m] = int.Parse(Console.ReadLine());
        }

        Console.Write("How many numbers do you looking for: ");
        int k = int.Parse(Console.ReadLine());

        int maxSum = int.MinValue;
        int curSum = 0;

        for (int i = 0; i < n; i++)
        {
            curSum = arr[i];
            for (int j = i + 1; j < i + k && j < n; j++)
            {
                curSum += arr[j];
            }
            if (curSum > maxSum)
            {
                maxSum = curSum;
            }
        }

        Console.WriteLine(maxSum);
    }
}