namespace OOPPrinciplesPart2
{
    using System;
    using OOPPrinciplesPart2.Interfaces;
    using Extensions;

    public class Cat : Animal, IAnimal
    {
        public const string SOUND = "Mew!";
        public Cat(string name):base(name)
        {
        }

        public string Mrrr()
        {
            return string.Format("Mrrr");
        }

        public override string Speak()
        {
            return base.Speak() + " " + SOUND;
        }
    }
}
