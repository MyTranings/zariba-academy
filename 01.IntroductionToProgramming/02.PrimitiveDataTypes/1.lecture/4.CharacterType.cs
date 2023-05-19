using System;

class ApplicationEntryPoint
{
    static void Main()
    {
        char someSymbol = 'k';
        Console.WriteLine("The character:'{0}' has number {1}.", someSymbol, (int)someSymbol);
        
        char anothersymbol = '\u0600';
        Console.WriteLine(anothersymbol);
    }
}
