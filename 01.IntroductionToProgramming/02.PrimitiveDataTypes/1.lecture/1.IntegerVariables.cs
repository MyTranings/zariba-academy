using System;
using System.Collections.Generic;
using System.Numerics;

class IntegerTypes
{
    static void Main()
    {
        //Declaring variables:
     // type   name  = value
        int number5 = 5;
        int numberOfLegsOfADog = 4;
        int numberOfEyes = 2;

        //Declaring different variables, according to most
        //   suitable data type.
        byte numberOfLegs = 4;
        sbyte temperatureOutside = -12;
        ushort currentYear = 2015;
        short deepestPlaceOnEarth = -11000; //metres
        int moneyISpentToday = - 2000000;
        uint moneyIWonToday = 2500000;
        long twoToThePowerFiftySix = (long)Math.Pow(2,56);
        BigInteger someLargeNumber = (BigInteger)twoToThePowerFiftySix*twoToThePowerFiftySix;
        Console.WriteLine(someLargeNumber);
    }
}

