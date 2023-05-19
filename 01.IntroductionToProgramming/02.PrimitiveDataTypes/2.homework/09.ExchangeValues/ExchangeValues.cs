// 9. Read two integer values from the console and exchange their values.
using System;

class ExchangeValues
{
    static void Main()
    {
        Console.Write("num1 is : ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("num1 is : ");
        int num2 = int.Parse(Console.ReadLine());
        int buff;
        buff = num1;
        num1 = num2;
        num2 = buff;
        Console.WriteLine("Values are exchanged. Now num1 is {0} and num2 is {1}", num1, num2);
    }
}