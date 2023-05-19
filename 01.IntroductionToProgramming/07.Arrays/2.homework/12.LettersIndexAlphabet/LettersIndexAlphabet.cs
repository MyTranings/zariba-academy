//12. Write a program that creates an array containing all letters from the alphabet(A-Z). 
//Read a word from the console and print the index of each of its letters in the array.

using System;

class LettersIndexAlphabet
{
    static void Main()
    {
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        Console.Write("Enter a word: ");
        char[] input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine(Array.IndexOf(alphabet, input[i]));
        }
    }
}