//20. Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set[1..N]. Example:
//	N = 5, K = 2 ? {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

class AllDistinctCombinations
{
    static void Main()
    {
        Console.Write("Enter a number for elements in array: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a number for combinations: ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[k];


        GetCombinations(arr, 0, 1, n);
    }

    private static void GetCombinations(int[] arr, int index, int curInd, int n)
    {   
        if (index == arr.Length)
        {
            PrintCombinations(arr);
        }
        else
        {
            for (int i = curInd; i <= n; i++)
            {
                arr[index] = i;
                GetCombinations(arr, index + 1, i + 1, n);
            }
        }
    }

    private static void PrintCombinations(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}