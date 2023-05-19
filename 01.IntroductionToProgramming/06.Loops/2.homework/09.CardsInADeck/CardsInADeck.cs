// 9. Write a program that prints all possible cards from a standard deck of 52 cards(without jokers). The cards should be printed with their English names.Use nested for loops and switch-case.
using System;

class CardsInADeck
{
    static void Main()
    {
        int cardNumbers = 52;
        int typeOfCards = 4;
        string curType = "";

        for (int i = 1; i <= typeOfCards; i++)
        {
            switch (i)
            {
                case 1: curType = "of clubs"; break;
                case 2: curType = "of diamonds"; break;
                case 3: curType = "of hearts"; break;
                case 4: curType = "of peak"; break;
                default: break;
            }
            for (int j = 1; j <= cardNumbers / typeOfCards; j++)
            {
                if (j > 9)
                {
                    switch (j)
                    {
                        case 10: Console.WriteLine("Jack {0}", curType); break;
                        case 11: Console.WriteLine("Queen of {0}", curType); break;
                        case 12: Console.WriteLine("King {0}", curType); break;
                        case 13: Console.WriteLine("Ace {0}", curType); break;
                        default: break;
                    }
                }
                else
                {
                    switch (j)
                    {
                        case 1: Console.WriteLine("Two {0}", curType); break;
                        case 2: Console.WriteLine("Three {0}", curType); break;
                        case 3: Console.WriteLine("Four {0}", curType); break;
                        case 4: Console.WriteLine("Five {0}", curType); break;
                        case 5: Console.WriteLine("Six {0}", curType); break;
                        case 6: Console.WriteLine("Seven {0}", curType); break;
                        case 7: Console.WriteLine("Eight {0}", curType); break;
                        case 8: Console.WriteLine("Nine {0}", curType); break;
                        case 9: Console.WriteLine("Ten {0}", curType); break;
                        default:break;
                    }
                }
            }
            Console.WriteLine(new String('-', 50));
        }
    }
}