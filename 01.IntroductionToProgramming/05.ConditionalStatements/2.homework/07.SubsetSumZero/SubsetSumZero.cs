// 7. *We are given 5 integer numbers. Write a program that checks if there is a subset of these 5 numbers which sums to zero.List all such sums.E.g. 5,0,-2,-3,1 should print 1.) 0 =0 2.) 5-2-3=0. 

using System;

class SubsetSumZero
{
    static void Main()
    {

        Console.Write("Enter a number: ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n3 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n4 = int.Parse(Console.ReadLine());

        Console.Write("Enter a number: ");
        int n5 = int.Parse(Console.ReadLine());

        if (n1 == 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n1);
        }
        if (n2 == 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n2);
        }

        if (n3 == 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n3);
        }

        if (n4 == 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n4);
        }

        if (n5 == 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n5);
        }

        // n1
        if (n1 == 0 && n1 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n1);
        }
        // + n2
        if (n1 + n2 == 0 && n1 != 0 && n2 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n1, n2);
        }
        // + n2 + n3
        if (n1 + n2 + n3 == 0 && n1 != 0 && n2 != 0 && n3 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n2, n3);
        }
        if (n1 + n2 + n3 + n4 == 0 && n1 != 0 && n2 != 0 && n3 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}, {3}", n1, n2, n3, n4);
        }
        if (n1 + n2 + n3 + n5 == 0 && n1 != 0 && n2 != 0 && n3 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}, {3}", n1, n2, n3, n5);
        }
        if (n1 + n2 + n3 + n4 + n5 == 0 && n1 != 0 && n2 != 0 && n3 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}, {3}, {4}", n1, n2, n3, n4, n5);
        }
        // + n2 + n4
        if (n1 + n2 + n4 == 0 && n1 != 0 && n2 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n2, n4);
        }
        if (n1 + n2 + n4 + n5 == 0 && n1 != 0 && n2 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n2, n4, n5);
        }
        // + n2 + n5
        if (n1 + n2 + n5 == 0 && n1 != 0 && n2 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n2, n5);
        }
        // + n3
        if (n1 + n3 == 0 && n1 != 0 && n3 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n1, n3);
        }
        if (n1 + n3 + n4 == 0 && n1 != 0 && n3 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n3, n4);
        }
        if (n1 + n3 + n5 == 0 && n1 != 0 && n3 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n3, n5);
        }
        // + n4
        if (n1 + n4 == 0 && n1 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n1, n4);
        }
        if (n1 + n4 + n5 == 0 && n1 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n1, n2, n4);
        }
        // + n5
        if (n1 + n5 == 0 && n1 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n1, n5);
        }


        // n2 
        if (n2 == 0 && n2 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n2);
        }
        // + n3
        if (n2 + n3 == 0 && n2 != 0 && n3 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n2, n3);
        }
        if (n2 + n3 + n4 == 0 && n2 != 0 && n3 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n2, n3, n4);
        }
        if (n2 + n3 + n4 + n5 == 0 && n2 != 0 && n3 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}, {3}", n2, n3, n4, n5);
        }
        // + n4
        if (n2 + n4 == 0 && n2 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n2, n4);
        }
        if (n2 + n4 + n5 == 0 && n2 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n2, n4, n5);
        }
        // + n5
        if (n2 + n5 == 0 && n2 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n2, n5);
        }


        // n3
        if (n3 == 0 && n3 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n3);
        }
        // + n4
        if (n3 + n4 == 0 && n3 != 0 && n4 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n3, n4);
        }
        if (n3 + n4 + n5 == 0 && n3 != 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}, {2}", n3, n4, n5);
        }
        // + n5
        if (n3 + n5 == 0 && n3 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n3, n5);
        }


        // n4
        if (n4 == 0 && n4 != 0 )
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n4);
        }
        // + n5
        if (n4 + n5 == 0 && n4 != 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}, {1}", n4, n5);
        }


        // n5
        if (n5 == 0 && n5 != 0)
        {
            Console.WriteLine("Numbers that subset is zero are: {0}", n5);
        }
    }
}
