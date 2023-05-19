using System;

class FirstWord
{
    static Random rng = new Random();
    static void Main()
    {
        string[] games = { "WOW", "LOL", "Dota 2","Bomberman","Portal", "Max Payne",
            "Fifa2007", "GTA", "CS:Go", "CS:1.6"};
        string firstGame = games[0];

        for (int i = 1; i < games.Length; i++)
        {
            if (string.Compare(games[i], firstGame) < 0)
            {
                firstGame = games[i];
            }
        }
        Console.WriteLine(firstGame);
    }
}

