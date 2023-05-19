// 4. Write an expression to check if the 3rd digit of an integer is 3. e.g. 2351 ?  true
using System;

class Check3rdDigit
{
    static void Main()
    {
        Console.Write("Enter a number to the number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Third number is 3: {0}", (n % 1000) / 100 == 3);
    }
}
