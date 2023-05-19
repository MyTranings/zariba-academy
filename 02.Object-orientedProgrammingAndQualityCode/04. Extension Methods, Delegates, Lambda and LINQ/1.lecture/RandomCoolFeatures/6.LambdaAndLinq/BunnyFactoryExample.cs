
namespace _6.LambdaAndLinq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Lambda
    {
        static void Main(string[] args)
        {
            // Action<string, int> myAction = (a, b) => Console.WriteLine("Lambda: {0},{1}", a, b);
            // Action<int> action2 = (x) => Console.WriteLine(x+7);
            // action2(5);

            var bunnyFactory = new List<Bunny>
            {
                new Bunny { FirstName="Pesho",LastName="Peshev",Age=3,Gender = BunnyGender.M},
                new Bunny { FirstName="Gosho",LastName="Ivanov",Age=7,Gender = BunnyGender.M},
                new Bunny { FirstName="Ivanka",LastName="Pesheva",Age=18,Gender = BunnyGender.F},
                new Bunny { FirstName="Mariela",LastName="Kuchkova",Age=15,Gender = BunnyGender.F},
                new Bunny { FirstName="Chefo",LastName="Todorov",Age=21,Gender = BunnyGender.M},
            };
            var list = new List<int> { 4, 1, 2, 5, 11, 3, 7 };

            var lessThanFive =
                from n in list
                where n < 5
                select n;
            var orderBy =
                from n in list
                orderby n
                select n+1000;
            var grownUpBunnies =
                from b in bunnyFactory
                orderby b.FirstName
                where b.Age >= 18
                select b.FirstName+" "+b.LastName;
            var genderBunnies =
                from bunny in bunnyFactory
                orderby bunny.FirstName
                group bunny by bunny.Gender;
            // foreach (var group in genderBunnies)
            // {
            //     Console.WriteLine(group.Key);
            //     foreach (var bunny in group)
            //     {
            //         Console.WriteLine(bunny.FirstName + " "+bunny.Gender);
            //     }
            // }
            //Make all possible pairs of bunnies
            var couples =
                 from bunny1 in bunnyFactory
                 from bunny2 in bunnyFactory
                 where bunny1.Gender != bunny2.Gender
                 select new { FirstBunny = bunny1, SecondBunny = bunny2 };
           // foreach (var couple in couples)
           // {
           //     Console.WriteLine(couple.FirstBunny.FirstName+" "+couple.SecondBunny.FirstName);
           // }
            // LAMBDA FROM NOW ON
            var filteredBunnies = bunnyFactory
                .Where(b => b.LastName.StartsWith("P"))
                .OrderByDescending(b => b.Age)
                .Select(b => new { FirstName = b.FirstName, LastName = b.LastName }) //projection of a smaller piece of information
                .ToList();
            // foreach (var bunny in filteredBunnies)
            // {
            //     Console.WriteLine(bunny.FirstName+" "+ bunny.LastName );
            // }
            var text = "Hi, my name is Martin. I am 24.";
            var result = text
                .Split(' ')
                .Where((w) => w.ToLower().StartsWith("m") || w.ToLower().StartsWith("i"));
            var smallBunnies = bunnyFactory
                .Where(b => b.Age < 10)
                .Select(b => b.FirstName +" " +b.Age)
                .ToList();
            var first = bunnyFactory
                .FirstOrDefault(b=> b.Age<0);
            //Console.WriteLine(first.FirstName);
            var anonymBunnyList = bunnyFactory
                .Where(b => b.Gender == BunnyGender.M)
                .Select(b => new { FirstName = b.FirstName, Gender = b.Gender })
                .ToList();
            var orderBunnies = bunnyFactory
                .OrderBy(b => b.Gender)
                .ThenByDescending(b => b.Age)
                .Select(b=> b.Gender + " "+b.Age)
                .ToList();
            var areThereGrownUpBunnies = bunnyFactory
                .Any(b => b.Age > 21);
            var areAllBunniesGrownUp = bunnyFactory
                .All(b => b.Age > 3);
            var reversedBunnies = bunnyFactory
                .Where(b => b.Age > 5)
                .Reverse()
                .Select(b => b.FirstName + b.Age);
            var averageBunnyAge = bunnyFactory
                .Average(b => b.Age);
            Console.WriteLine(averageBunnyAge);

            var couples2 = bunnyFactory
                .SelectMany(b1 => bunnyFactory.Select(b2 => b1.FirstName + b2.FirstName));
            foreach (var couple in couples2)
            {
                Console.WriteLine(couple);
            }

            var groups = bunnyFactory
                .GroupBy(b => b.Gender)
                .ToList();
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var bunny in group)
                {
                    Console.WriteLine(bunny.FirstName+" "+bunny.Gender);
                }
            }
            //Print(reversedBunnies);

            //Console.WriteLine(areAllBunniesGrownUp);
           // Print(orderBunnies);
           //foreach (var bunny in anonymBunnyList)
           //{
           //    Console.WriteLine(bunny.FirstName + " " + bunny.Gender);
           //}
            //Print(smallBunnies);
        }
        public static void Print(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
