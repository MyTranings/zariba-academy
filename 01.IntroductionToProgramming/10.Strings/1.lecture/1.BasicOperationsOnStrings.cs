using System;

class BasicOperationsOnStrings
{
    static void Main()
    {
        string logo1 = "Zariba Academy";
        String logo2 = "ZaribaAcademy";
        System.String logo3 = "zariba academy";
        Console.WriteLine(logo1.Length);
        Console.WriteLine(logo1[5]);
        //This is for arrays
        //int[] array = { 1, 3, 4 };
        //int[] anotherArray = array;
        //array[1] = 2;
        //Console.WriteLine(string.Join(", ",anotherArray));
        logo2 = logo1;
        logo1 = logo1 + "534";
        
        Console.WriteLine(logo2);

        //Initializing strings
        string s; // s = null which is not the same as ""
        string s1 = "Giving a value of my string";
        string s2 = s1;
        string s3 = 50.ToString();

        //Reading from the console
        string line = Console.ReadLine();
        Console.WriteLine(line);
        //Iterating
        for (int i = 0; i < line.Length; i++)
        {
            Console.WriteLine("s[{0}]={1}",i,line[i]);
        }
        foreach (var letter in line)
        {
            Console.Write("{0} ",letter);
        }
    }
}

