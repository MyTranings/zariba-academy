using System;

class Foreach
{
    static void Main()
    {
        string[] daysOfTheWeek = {"Monday","Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday", "Sunday" };

        foreach (var day in daysOfTheWeek)
        {
            Console.WriteLine(day);
        }
        //Reasons why foreach is better
        //1.) It cannot be an infiteLoop
        //2.) You do not need to know how big the collection is
        //3.) Easier to read
        //4.) You may not have an indexer
        //5.) It is a lot more abstact
    }
}