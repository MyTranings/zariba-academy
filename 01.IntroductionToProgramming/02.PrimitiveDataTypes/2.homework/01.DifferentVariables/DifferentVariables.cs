//1. Declare a variable for each of the data types in this lecture and assign an appropriate value.

using System;
using System.Numerics;

class DifferentVariables
{
    static void Main()
    {
        // Integer Variables
        sbyte signByte = -128;
        byte unsignedByte = 255;
        short signShort = -31565;
        ushort unsignedShort = 65535;
        int signedInteger = -14701578;
        uint unsignedInteger = 4294547565;
        long signedLong = -9222034685477780;
        ulong unsignedLong = 18446744073709551600;
        BigInteger exampleBigInteger = (BigInteger)Math.Pow(unsignedLong, 2);

        Console.WriteLine(signByte);
        Console.WriteLine(unsignedByte);
        Console.WriteLine(signShort);
        Console.WriteLine(unsignedShort);
        Console.WriteLine(signedInteger);
        Console.WriteLine(unsignedInteger);
        Console.WriteLine(signedLong);
        Console.WriteLine(unsignedLong);
        Console.WriteLine(exampleBigInteger);

        // Floating point Variables
        float exampleFloat = 1.234567f;
        double exampleDouble = 1.23456789012345;
        decimal exampleDecimal = (decimal)1.234567890123456789;

        Console.WriteLine(exampleFloat);
        Console.WriteLine(exampleDouble);
        Console.WriteLine(exampleDecimal);

        // Boolean Variables
        bool amIAlive = true;
        bool amIAGameDeveloper = false;

        // Char Variables
        char exampleChar = 'D';
        char exampleCharUnicode = '\u0044';

        Console.WriteLine(exampleCharUnicode);

        // String Variables
        string stringVar1 = "Learning";
        string stringVar2 = "programing in";
        string stringVar3 = "Zariba Academy!";

        Console.WriteLine("{0} {1} {2}", stringVar1, stringVar2, stringVar3);

        // Object Variables
        object exampleObject = 23;
        exampleObject = '\u0044';
        exampleObject = "New value for object variable";

        Console.WriteLine(exampleObject);

        // Dynamic Variables
        dynamic exampleDynamic = 123;
        dynamic exampleDynamicChar = '7';

        Console.WriteLine(exampleDynamic.GetType());
        Console.WriteLine(exampleDynamicChar.GetType());
        Console.WriteLine("Dynamic 1 is {0} = {1}, dynamic 2 is {2} = {3}, print then with concatination = {4}", exampleDynamic.GetType(), exampleDynamic, exampleDynamicChar.GetType(), exampleDynamicChar, exampleDynamic + exampleDynamicChar);
    }
}