namespace MyFraction
{
    using System;

    public class Fraction
    {
        private const string EXEPTION_MESSAGE = "A fraction can't have 0 as a";
        private const string EXEPTION_MESSAGE_DECIMAL = "Decimal numbers are not allowed as a";

        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.FractionString = (this.Numerator.ToString() + "/" + this.Denominator.ToString()).ToString();
            this.Value = numerator / denominator;
        }

        public int Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(EXEPTION_MESSAGE + " numerator!");
                }
                else if (value % 1 != 0)
                {
                    throw new ArgumentException(EXEPTION_MESSAGE_DECIMAL + " numerator!");
                }

                this.numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException(EXEPTION_MESSAGE + " denominator!");
                }
                else if (value % 1 != 0)
                {
                    throw new ArgumentException(EXEPTION_MESSAGE_DECIMAL + " denominator!");
                }

                this.denominator = value;
            }
        }

        public string FractionString { get; private set; }

        public double Value { get; private set; }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction result;

            if (f1.Denominator != f2.Denominator)
            {
                int lcd = LCD(f1.Denominator, f2.Denominator);
                result = new Fraction((f1.Numerator * (lcd / f1.Denominator)) + (f2.Numerator * (lcd / f2.Denominator)), lcd);
            }
            else
            {
                result = new Fraction(f1.Numerator + f2.Numerator, f1.Denominator);
            }

            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction result;

            if (f1.Denominator != f2.Denominator)
            {
                int lcd = LCD(f1.denominator, f2.denominator);
                result = new Fraction((f1.Numerator * (lcd / f1.Denominator)) - (f2.Numerator * (lcd / f2.Denominator)), lcd);
            }
            else
            {
                result = new Fraction(f1.Numerator - f2.Numerator, f1.Denominator);
            }

            return result;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);

            return result;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);

            return result;
        }

        private static int LCD(int denominator1, int denominator2)
        {
            return (denominator1 * denominator2) / GCD(denominator1, denominator2);
        }

        private static int GCD(int denominator1, int denominator2)
        {
            while (denominator1 != denominator2)
            {
                if (denominator1 > denominator2)
                {
                    denominator1 -= denominator2;
                }

                if (denominator2 > denominator1)
                {
                    denominator2 -= denominator1;
                }
            }

            return denominator1;
        }
    }
}
