// 3. Sort 3 integer numbers using if statements.

using System;

class Sort3Number
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n3 = int.Parse(Console.ReadLine());

        if (n1 <= n2 && n1 <= n3)
        {
            if (n2 <= n3)
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n1, n2, n3);
            }
            else
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n1, n3, n2);
            }
        }
        else if (n2 <= n1 && n2 <= n3)
        {
            if (n1 <= n3)
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n2, n1, n3);
            }
            else
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n2, n3, n1);
            }
        }
        else
        {
            if (n1 <= n2)
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n3, n1, n2);
            }
            else
            {
                Console.WriteLine("Order of the number is: {0}, {1}, {2}", n3, n2, n1);
            }
        }

    }
}
