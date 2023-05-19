//10. Write a program that finds in given array of integers a sequence of given sum S(if present). 
//	Example: {4, 3, 1, 4, 2, 5, 8}, S=11 ? {4, 2, 5}	

using System;

class FindsArrayInASequenceOfSum
{
    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        Console.Write("Enter a sum to find in array: ");
        int s = int.Parse(Console.ReadLine());

        int bufSum = int.MinValue;
        int startIndex = int.MinValue,
            endIndex = int.MinValue;


        for (int i = 0; i < arr.Length; i++)
        {
            bufSum = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                bufSum += arr[j];
                if (bufSum == s)
                {
                    startIndex = i;
                    endIndex = j;
                    break;
                }
                else if (bufSum > s)
                {
                    break;
                }
            }
            if (bufSum == s)
            {
                Console.Write("The sequence with sum of {0} is: ", s);
                for (int k = startIndex; k <= endIndex; k++)
                {
                    Console.Write("{0}, ", arr[k]);
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.WriteLine(' ');
            }
        }
    }
}