using System;

class CloningAnArray
{
    static void Main()
    {
        //this doesn't work.
        int[] array = { 1, 2, 3, 4, 5 };
        int[] failCopyArray = array;
        Console.WriteLine(string.Join(", ",failCopyArray));
        array[4] = -1;
        Console.WriteLine(string.Join(", ", failCopyArray));

        int[] copyArray = (int[])array.Clone();
        Console.WriteLine(new string('-',50));
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine(string.Join(", ", copyArray));
        array[4] = 5;
        Console.WriteLine(new string('-', 50));
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine(string.Join(", ", copyArray));

        //nikola mihailovski 4

    }
}

