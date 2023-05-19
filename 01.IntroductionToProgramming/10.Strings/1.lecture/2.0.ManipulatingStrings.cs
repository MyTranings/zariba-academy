using System;

class ManipulatingStrings
{
    static void Main()
    {
        //Comparison
        string logo1 = "Zariba";
        string logo2 = "zariba";
        int result = string.Compare(logo2, logo1, false);
        Console.WriteLine(result);

        //Another way for case insensitive comparison.
        if (logo1.ToLower() == logo2.ToLower())
        {
            Console.WriteLine("Logo1 = logo2");
        }
        else if (logo1 != logo2)
        {
            Console.WriteLine("Logo1!=logo2");
        }

        if (logo1.Equals(logo2))
        {
            Console.WriteLine("Logo1 = logo2 with Equals Method");
        }
        else if (!logo1.Equals(logo2))
        {
            Console.WriteLine("Logo1!=logo2 with EqualsMethod");
        }

        Console.WriteLine();
        //ConcatenatingStrings
        string logo3 = string.Concat(logo1, logo2);
        Console.WriteLine(logo3);
        string logo4 = logo3 + logo3;
        Console.WriteLine(logo4);
        Console.WriteLine();
        //Searching
        //IndexOf(string str1) --> Position of first occurence of str1
        //LastIndexOf(string str1) --> Position of the last occurence of str1
        //IndexOf(string str1, int startIndex) --> Position of the first occurence
        //     of str1 after the startIndex
        string longerLogo = "Zariba Game Academy";
        Console.WriteLine(longerLogo.IndexOf("Academy"));
        Console.WriteLine(longerLogo.IndexOf("AcAdEMY"));
        Console.WriteLine(longerLogo.IndexOf("a"));
        Console.WriteLine(longerLogo.LastIndexOf("a"));
        Console.WriteLine(longerLogo.IndexOf("a", 3));
        Console.WriteLine(longerLogo.IndexOf("a", 6));

        Console.WriteLine();
        //Extracting strings
        //string.Substring(int startIndex, int Length);
        string extractedLogo = longerLogo.Substring(5);
        Console.WriteLine(extractedLogo);

        string fullPath = @"C:\\ZaribaAcademy\Games\Mascot.png";
        string path = fullPath.Substring(0, fullPath.LastIndexOf("\\"));
        string fileName = fullPath.Substring(fullPath.LastIndexOf("\\") + 1,
            fullPath.LastIndexOf(".") - fullPath.LastIndexOf("\\") - 1);
        string fileType = fullPath.Substring(fullPath.LastIndexOf(".") + 1);
        Console.WriteLine(path);
        Console.WriteLine(fileName);
        Console.WriteLine(fileType);

        //Splitting
        string games = "WOW LOL DOTA2 SomeOtherGame,,, CallOfDuty.    TheLost Vikings! ...";
        char[] separators = { ' ', ',', '.', '!', };
        string[] stringArray = games.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var game in stringArray)
        {
            Console.WriteLine(game);
        }
    }
}

