using System;

class LogicalOperators
{
    static void Main(string[] args)
    {
        bool iHaveMoney = false;
        bool youHaveMoney = false;
        Console.WriteLine("Are we drinking beer/soda tonight? {0} ",iHaveMoney||youHaveMoney);

        bool amISober = true;
        bool doIHaveACar = true;
        Console.WriteLine("Am I driving home from the club? {0}", amISober && doIHaveACar);

        bool firstGirlfriendOut = true;
        bool secondGirlfriendOut = true;
        Console.WriteLine("Am I going out tonight? {0}", firstGirlfriendOut^secondGirlfriendOut);

    }
}

