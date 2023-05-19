namespace SimpleFactory
{
    using System;

    public class Hero
    {
        public Hero(int strength, int agility, int intelligence)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
    }
}
