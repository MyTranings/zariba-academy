using System;

class DynamicType
{
    static void Main()
    {
        //DO NOT EVER use dynamic.
        dynamic someRandomDynamicNonsense = 5;
        dynamic anotherRandomDynamicNonsense = "3";
        Console.WriteLine(someRandomDynamicNonsense+anotherRandomDynamicNonsense);        
    }
}

