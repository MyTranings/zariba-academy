using System;

class ObjectType
{
    static void Main()
    {
        //int number = 5;
        //char symbol = 'a';
        //Do not use the one below in C#
        //var anotherNumber = 8;
        //var anotherSymbol = 'b';
        //Do not use, unless some very special case occurs
        object someNumber = 5;
        someNumber = "Bunny";
        Console.WriteLine(someNumber);
        someNumber = 123;
        Console.WriteLine(someNumber);
        string someString = "bunny";
    }
}

