//06.Declare two string variables and assign them with Zariba and Academy. Declare an object variable and assign it with the concatenation of the first two variables(mind adding an interval). Declare a third string variable and initialize it with the value of the object variable(you should perform type casting).

using System;

class ObjectType
{
    static void Main()
    {
        string zariba = "Zariba";
        string academy = "Academy";
        object zaribaAcademy = zariba + " " + academy;
        string zAcademy = (string)zaribaAcademy;
        Console.WriteLine(zAcademy.GetType());
    }
}