using System;
//Lecturer 1-0

class SwitchCase
{
    static void Main()
    {
        //Given a day from 1 to 7, print the name of the day
        int day = int.Parse(Console.ReadLine());



        switch (day)
        {
            case -2:
            case -1:
            case 0:
                        case 1: Console.WriteLine("Monday");break;
                        case 2: Console.WriteLine("Tuesday");break;
                 case 3: Console.WriteLine("Wednesday"); break;
            case 4: Console.WriteLine("Thursday"); break;


            case 5: Console.WriteLine("Friday"); break;
            case 6: Console.WriteLine("Saturday"); break;
            case 7: Console.WriteLine("Sunday"); break;


            default:
                Console.WriteLine("Days are from 1 to 7. You suck!");
                break;





        }
    }
}

