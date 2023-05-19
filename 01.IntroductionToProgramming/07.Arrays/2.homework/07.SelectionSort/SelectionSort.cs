//7. Sorting an array means to arrange its elements in increasing order.Write a program to sort an array. 
// Use the "selection sort" algorithm.Hint: Search on Google.

using System;

class SelectionSort
{
    static void Main()
    {
        int[] arr = { 2, 3, 32, 1, 4, 9, 3, 6, 1, 4, 3, 0, 103, 6, 4, 5 };
        int minVal = arr[0];
        int buffer = 0;

        for (int i = 0; i < arr.Length; i++)
        {

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[i])
                {
                    buffer = arr[i];
                    arr[i] = arr[j];
                    arr[j] = buffer;
                }
            }
        }
        foreach (int item in arr)
        {
            Console.WriteLine(item);
        }
    }
}