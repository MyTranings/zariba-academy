using System;
using System.Collections.Generic;

class OtherOperators
{
    static void Main(string[] args)
    {
        string word1 = "Zariba";
        string word2 = "Academy";
        string result = word1 + word2;
        Console.WriteLine(result);

        int number = 17;
        bool result1 = ((number % 2) == 1) ? true : false;
        Console.WriteLine(result1);

        Console.WriteLine(typeof(List<int>));
        Console.WriteLine(sizeof(int));

        //Type Conversions
        //explicit
        double someNumber = 5.05;
        float anotherNumber = (float)someNumber;

        //implicit
        int evenAnotherNumber = 32;
        long evenAnotherNumberNumber = evenAnotherNumber;
    }
}

