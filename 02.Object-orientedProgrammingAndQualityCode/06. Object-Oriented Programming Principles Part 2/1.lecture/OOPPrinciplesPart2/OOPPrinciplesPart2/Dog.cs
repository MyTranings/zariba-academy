namespace OOPPrinciplesPart2
{
    using System;
    using Interfaces;
    using Extensions;

    public class Dog : Animal, IAnimal
    {
        public const string SOUND = "Wuf";

        public Dog(string name)
            : base(name)
        {
        }

        public string Dig()
        {
            return string.Format("Where is my bone?");
        }

        public override string Speak()
        {
            return base.Speak() + " " + SOUND;
        }
    }
}
