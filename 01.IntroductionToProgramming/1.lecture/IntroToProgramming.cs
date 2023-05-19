using System;
using System.Threading;

class IntroToProgramming
{
    static void Main()
    {
        //This gives the integer part of dividing 5 by 3
        // 5=3x1 + 2 
        Console.WriteLine(5/3);
        //This gives the remainder of dividing 5 by 3
        Console.WriteLine(5%3);

        //First way for a new line
        Console.WriteLine("Zariba");
        Console.WriteLine();
        Console.WriteLine("Academy");

        //Second way for a new line
        Console.WriteLine("Zariba\n\n\n\n\nAcademy");

        //Make a beep and delay execution of commands
        Console.Beep();
        Console.WriteLine("\a");
        //Thread.Sleep(1000);
        Console.WriteLine("\a");
        //Thread.Sleep(1000);
        Console.WriteLine("\a");
        //Thread.Sleep(1000);
        Console.WriteLine("\a");

        //Clear a part of the console
        //Console.Clear();

        //Math Class
        Console.WriteLine(Math.Pow(2,7));
        Console.WriteLine(Math.Sqrt(50));

        //Change the title of the console
        Console.Title = "Zariba Academy Demo";

        //Add a bit of sweet colour :)
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Zariba Academy Demo");
        //To hold the console for the exe file
        Console.ReadKey();
    }
}

