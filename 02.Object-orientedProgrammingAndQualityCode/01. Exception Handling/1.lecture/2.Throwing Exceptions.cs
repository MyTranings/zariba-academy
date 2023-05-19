using System;

namespace ThrowExceptions
{
    class ThrowingExceptions
    {
        struct SpiderBunny
        {
            public string Name;
            public int NumberOfLegs;
        }
        static void Main(string[] args)
        {
            SpiderBunny myBunny = new SpiderBunny();

            try
            {
                Console.Write("Input number of legs: ");
                int numberOfLegs = int.Parse(Console.ReadLine());

                if (numberOfLegs < 4 && numberOfLegs >= 0)
                {
                    throw new ArgumentOutOfRangeException("Poor bunny! You are a mean mean person. More than 4 legs please.");
                }
                if (numberOfLegs < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of legs has to be a positive number");
                }
                myBunny.NumberOfLegs = numberOfLegs;
            }
            catch (FormatException)
            {
                Console.WriteLine("Number of legs should be an integer!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not so many legs please!");
            }

            Console.Write("Input SpiderBunnyName:");
            string name = Console.ReadLine();

            if (name.Length<2)
            {
                throw new ArgumentOutOfRangeException("The spider bunny should have a name with more than 2 characters.");
            }
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException("Please, don't leave the spider bunny without a name :( ");
            }
            myBunny.Name = name;
           
            Console.WriteLine("The spider bunny has {0} legs and is called {1}.",myBunny.NumberOfLegs,myBunny.Name );

            SomeRandomMethodToShowException();
        }

        private static void SomeRandomMethodToShowException()
        {
            throw new NotImplementedException();
        }
    }
}
