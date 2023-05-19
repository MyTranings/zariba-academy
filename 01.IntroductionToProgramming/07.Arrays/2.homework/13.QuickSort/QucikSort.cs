//13. Write a program that sorts an array of strings using the quick sort algorithm.Search on Google.


using System;
using System.Collections.Generic;
using System.Linq;

class QuickSort
{
    static void Main()
    {
        //int[] arr = { 4, 1, 2, 3, 9, -6, -1, 6, -8, 8 };

        List<int> arr = new List<int>() { 5, 3, 2, 8, 7, 6, 1, 9, 4 };

        Sort(arr);

        int n = arr[0];

        List<int> smaller = new List<int>();
        List<int> bigger = new List<int>();

        //for (int i = 1; i < arr.Length; i++)
        //{
        //    if (arr[i] > n)
        //    {
        //        bigger.Add(arr[i]);
        //    }
        //    else if (arr[i] <= n)
        //    {
        //        smaller.Add(arr[i]);
        //    }
        //}

        //Sort(smaller);
    }

    private static List<int> Sort(List<int> arr)
    {
        List<int> smaller = new List<int>();
        List<int> bigger = new List<int>();

        int n = arr[0];

        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] > n)
            {
                bigger.Add(arr[i]);
            }
            else if (arr[i] <= n)
            {
                smaller.Add(arr[i]);
            }
        }

        if (arr.Any())
        {
            smaller = Sort(smaller);
        }
        if (arr.Any())
        {
            bigger = Sort(bigger);
        }
        //List<int> res = System.Collections.Generic.List.concat[smaller, n, bigger];

        //return List.concat();
        return smaller;
    }
}