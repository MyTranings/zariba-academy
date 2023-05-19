
namespace _2.AnonymousTypes
{
    using System;

    class AnonymousTypes
    {
        public static void SomeMethod(dynamic bunny)
        {
            Console.WriteLine(bunny.FirstName);
        }
        static void Main()
        {
            var bunny = new { FirstName = "Pesho", SecondName = "Gosho", Gender = "M" };
            SomeMethod(bunny);

            var ints = new[] { 1, 2, 3 };
            var anonymousArrayBunnies = new[]
            {
                new { Firstname = "Pesho", Age = 15},
                new { Firstname = "Gosho", Age = 13},
                new { Firstname = "Fuzzy", Age = 11},
                new { Firstname = "Tosho", Age = 10}
            };
        }
    }
}
