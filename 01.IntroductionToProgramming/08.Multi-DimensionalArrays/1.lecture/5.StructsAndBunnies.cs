using System;

class Bunnies
{
    struct Bunny
    {
        public string Name;
        public int Number;
        public int Health;

        public Bunny(string name, int number, int health)
        {
            this.Name = name;
            this.Number = number;
            this.Health = health;
        }

        public override string ToString()
        {
            return "Name: "+this.Name + " Number: "+this.Number+ " Health: "+this.Health;
        }
    }
    static void Main()
    {
        Bunny[] myBunnies = {
            new Bunny("Pesho Junior",1,200),
            new Bunny("Gosho",2,100),
            new Bunny("Toshko Senior",3,500),
            new Bunny("Oleg from the Garden",4,250),
        };

        PrintBunnies(myBunnies);
        Console.WriteLine("Sort Bunnies by Name Length: ");
        Array.Sort(myBunnies, (x, y) => x.Name.Length.CompareTo(y.Name.Length));
        PrintBunnies(myBunnies);
        Console.WriteLine("Sort Bunnies by Number Reverse: ");
        Array.Sort(myBunnies, (x, y) => y.Number.CompareTo(x.Number));
        PrintBunnies(myBunnies);
        Console.WriteLine("Sort Bunnies by Health");
        Array.Sort(myBunnies, (x, y) => x.Health.CompareTo(y.Health));
        PrintBunnies(myBunnies);
    }

    private static void PrintBunnies(Bunny[] myBunnies)
    {
        Console.WriteLine(new string('-',50));
        foreach (var bunny in myBunnies)
        {
            Console.WriteLine(bunny.ToString());
        }
        Console.WriteLine(new string('-', 50));
    }
}

