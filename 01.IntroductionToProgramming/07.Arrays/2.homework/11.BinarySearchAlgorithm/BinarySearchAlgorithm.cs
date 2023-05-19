//11. Write a program that finds the index of given element in a sorted array of integers by using the 
//binary search algorithm(find it in Wikipedia).

using System;

class BinarySearchAlgorithm
{
    static void Main()
    {
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.Write("Enter a number to find: ");
        int n = int.Parse(Console.ReadLine());
        int startIndex = 0;
        int endIndex = arr.Length;
        int midPoint = arr.Length / 2;


        while (arr[midPoint] != n)
        {
            midPoint = startIndex + (endIndex - startIndex) / 2;

            if (arr[midPoint] < n)
            {
                startIndex = midPoint + 1;
            }
            else if (arr[midPoint] > n)
            {
                endIndex = midPoint - 1;
            }
            else
            {
                Console.WriteLine(midPoint);
            }
        }
    }
}