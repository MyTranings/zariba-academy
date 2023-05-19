using System;

class TheArrayClass
{
    static void Main()
    {
        //1.) Rank -> Number of Dimensions
        //2.) Length -> Number of elements in all dimensions
        //3.) GetLength(dimension) -> Number of elements in a specific dimensions 
        //4.) BinarySearch -> Very fast searching algorithm in a sorted array
        //5.) IndexOf -> The first index of an element in an array
        //6.) LastIndexOf -> The last index of an element in an array
        //7.) Copy(src,dest,len) -> self-explanatory
        //8.) Reverse -> Self explanatory
        //9.) Clear() -> self explanatory
        //10.) Sort() -> orders the elements with some comparison property

        int[] array = { 5, 3, 1, 3, 2, 1, 0 };
        int[,] matrix = {
            { 5, 1, 3 },
            { 2, 3, 7 }
        };
        string[] gamesArray = { "WOW", "LOL", "Dota 2", "Smite", "HeroesOfNewerth", "Portal", "WOW" };

        PrintAllArrays(array, matrix, gamesArray);
        Console.WriteLine("Array Rank: {0}",array.Rank);
        Console.WriteLine("Matrix Rank: {0}",matrix.Rank);
        Console.WriteLine("Matrix Length: {0}",matrix.Length);
        Console.WriteLine("Matrix Rows: {0}",matrix.GetLength(0));
        Console.WriteLine("Matrix Cols: {0}",matrix.GetLength(1));
        Console.WriteLine("Index Of Portal: {0}",Array.IndexOf(gamesArray,"Portal"));
        Console.WriteLine("Last Index of WOW: {0}",Array.LastIndexOf(gamesArray,"WOW"));
        Console.WriteLine("Index of non-existend value: {0}", Array.IndexOf(gamesArray, "Half-Life"));

        string[] gamesCopy = new string[5];
        Array.Copy(gamesArray, gamesCopy, gamesCopy.Length);
        Console.WriteLine("Copying the first 5 games: ");
        PrintAllArrays(gamesArray);
        PrintAllArrays(gamesCopy);
        Console.WriteLine("Clearing Games Copy: ");
        Array.Clear(gamesCopy, 0, gamesCopy.Length);
        PrintAllArrays(gamesCopy);

        Console.WriteLine("Sorting Games Array - default: ");
        Array.Sort(gamesArray);
        PrintAllArrays(gamesArray);
        Console.WriteLine("Sorting Games Array - default,reverse: ");
        Array.Sort(gamesArray, (game1, game2) => game2.CompareTo(game1));
        PrintAllArrays(gamesArray);
        Console.WriteLine("Sorting Games Array by Length: ");
        Array.Sort(gamesArray, (x, y) => x.Length.CompareTo(y.Length));
        PrintAllArrays(gamesArray);
        Array.Sort(gamesArray);
        Console.WriteLine("Ready for Binary Search: ");
        PrintAllArrays(gamesArray);

        //Binary Search -> very fast searching in a sort array
        Console.WriteLine("\nIndex of HeroesOfNewerth: {0}",Array.BinarySearch(gamesArray,"HeroesOfNewerth"));


    }

    private static void PrintAllArrays(int[] array, int[,] matrix, string[] gamesArray)
    {
        Console.WriteLine(new string('-',50));
        Console.WriteLine("Array: {0}",string.Join(", ",array));
        Console.WriteLine("Matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ",matrix[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("Games Array: {0}",string.Join(", ",gamesArray));
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
    }
    private static void PrintAllArrays(string[] gamesArray)
    {
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Games Array: {0}", string.Join(", ", gamesArray));
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
    }
}

