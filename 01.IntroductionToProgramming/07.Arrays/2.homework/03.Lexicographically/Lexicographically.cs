// 3. Write a program that compares two char arrays lexicographically(letter by letter).

using System;

class Lexicographically
{
    static void Main()
    {
        char[] arr1 = { 'a', 'b', '?', 'd', 'e' };
        char[] arr2 = { 'f', '2', 'h', '#', 'c' };

        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                if (arr1[i] > arr2[j])
                {
                    Console.WriteLine("arr1[{0}] = {1} is after arr2[{2}] = {3}!", i, arr1[i], j, arr2[j]);
                }
                else if (arr1[i] < arr2 [j])
                {
                    Console.WriteLine("arr1[{0}] = {1} is before arr2[{2}] = {3}!", i, arr1[i], j, arr2[j]);
                }
                else
                {
                    Console.WriteLine("arr1[{0}] = {1} are equal arr2[{2}] = {3}!", i, arr1[i], j, arr2[j]);
                }
            }
        }
    }
}