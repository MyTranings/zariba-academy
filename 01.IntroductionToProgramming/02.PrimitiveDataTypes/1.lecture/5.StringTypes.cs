using System;
using System.Text;

class StringTypes
{
    static void Main()
    {
        string someText = "Zariba";
        string anotherText = "Academy";
        //This is the same as the line below
        //   but easier to use
        //Console.WriteLine(someText+" "+anotherText);
        Console.WriteLine("{0} {1}",someText,anotherText);
    }
}

