using System;

class Return
{
    static void Main()
    {
        int multiplication = MultiplyNumbers(2,5);
        Console.WriteLine(multiplication);
        //An array of integers and check if all of them are positive.
        int[] someNumbersToCheck = { 1, -2, 3, 4, 10 };
        bool isPositive = ArePositive(someNumbersToCheck);
        Console.WriteLine("Are all numbers Positive? {0}",isPositive);
    }
    static int MultiplyNumbers(int num1, int num2)
    {
        return num1 * num2;
    }
    static bool ArePositive(int[] array)
    {
        foreach (var number in array)
        {
            if (number<0)
            {
                return false;
            }
        }
        return true;
    }

}

