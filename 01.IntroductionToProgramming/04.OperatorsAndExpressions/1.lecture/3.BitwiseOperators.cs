using System;

class BitwiseOperators
{
    static void Main()
    {
        byte firstNumber = 5;  //0000 0101
        byte secondNumber = 7; //0000 0111
                               //0000 0010
        Console.WriteLine("5|7 is: {0}", Convert.ToString(firstNumber | secondNumber, 2).PadLeft(8,'0')); //0000 0111
        Console.WriteLine("5&7 is: {0}", Convert.ToString(firstNumber & secondNumber, 2).PadLeft(8, '0')); //0000 0101
        Console.WriteLine("5^7 is: {0}", Convert.ToString(firstNumber ^ secondNumber, 2).PadLeft(8, '0')); //0000 0101
        Console.WriteLine("\n\n\n");

        //Get the bit of a number n at position p
        int p = 5;
        int n = 35;             //0010 0011
        int mask = 1 << p;      //0010 0000
        mask = mask & n;        //0010 0000
        mask = mask >> p;       //0000 0001
        Console.WriteLine("Bit at position p of n is: {0}", Convert.ToString(mask,2));

        //easier way
        //int p1 = 5;
        //int n1 = 35;
        //int result = (n1 >> p1) % 2;
        //To comment -> select and press ctrl+k + c, to uncomment ctrl + k + u



        //Set the bit at position p to be 0
        int p1 = 0;
        int n1 = 35;             //0010 0011
        int mask1 = 1 << p1;      //0010 0000
        mask1 = ~mask1;          //1101 1111
        int result = mask1 & n1;  //0000 0011 ->3= 1+2=3
        Console.WriteLine(result);

        int number = 24;
        Console.WriteLine(number>>2);
    }
    
}

