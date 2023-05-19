namespace MyFraction
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            Fraction customFraction = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 15);

            Fraction r1 = customFraction + f2;
            Console.WriteLine(r1.FractionString);
            Console.WriteLine(r1.Value);
            Fraction r2 = customFraction - f2;
            Console.WriteLine(r2.FractionString);
            Console.WriteLine(r2.Value);
            Fraction r3 = customFraction * f2;
            Console.WriteLine(r3.FractionString);
            Console.WriteLine(r3.Value);
            Fraction r4 = customFraction / f2;
            Console.WriteLine(r4.FractionString);
            Console.WriteLine(r4.Value);
        }
    }
}
