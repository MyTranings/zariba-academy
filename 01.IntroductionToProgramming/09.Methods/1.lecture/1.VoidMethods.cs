using System;

class VoidMethods
{
    static void Main()
    {
        
        PrintLogo();
        int number = int.Parse(Console.ReadLine());
        PrintSign(number);
        PrintMax(5, 10);
        SayMonth(number);

    }

    static void PrintMax(float v1, float v2)
    {
        if (v1 > v2)
        {
            Console.WriteLine("The number {0} is bigger", v1);
        }
        else if (v2 > v1)
        {
            Console.WriteLine("The number {0} is bigger", v2);
        }
        else
        {
            Console.WriteLine("They are equal.");
        }
    }

    static void PrintLogo() //PascalCase 
    {
        Console.WriteLine("Zariba");
        Console.WriteLine("Game");
    }
    static void PrintSign(int givenNumber) //given number is like the abstract "x"
    {
        if (givenNumber>0)
        {
            Console.WriteLine("Positive");
        }
        else if (givenNumber<0)
        {
            Console.WriteLine("Negative");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
    static void SayMonth(int month)
    {
        string[] months = { "January", "February", "March", "April",
            "May", "June","July", "August", "September",
            "October", "November", "December"};
        Console.WriteLine(months[(month-1)%12]);
    }
}


