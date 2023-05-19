using System;

class OtherMethods
{
    static void Main()
    {
        //Replacing
        string bunnyNames = "Pesho+Joro Senior+Gosho Junior";
        string properBunnyNames = bunnyNames.Replace("+", " and ");
        Console.WriteLine(bunnyNames);
        Console.WriteLine(properBunnyNames);
        Console.WriteLine();
        //Removing strings
        string price = "$123456";
        string cutPrice = price.Remove(2,3);
        Console.WriteLine(cutPrice);
        Console.WriteLine();
        //To Upper To lower
        string bunnyUpper = bunnyNames.ToUpper();
        Console.WriteLine(bunnyUpper);
        string bunnyLower = bunnyNames.ToLower();
        Console.WriteLine(bunnyLower);

        //Trim, TrimStart, Trim end
        string logo = "      \t\n\n\n Zariba    \n\n\n\n ";
        Console.WriteLine(logo.Trim()+"1");
        Console.WriteLine(logo.TrimStart()+"1");
        Console.WriteLine(logo.TrimEnd()+"1");
    }
}

